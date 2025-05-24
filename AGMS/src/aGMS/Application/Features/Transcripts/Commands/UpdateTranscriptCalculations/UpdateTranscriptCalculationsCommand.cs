using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transcripts.Commands.UpdateTranscriptCalculations;

public class UpdateTranscriptCalculationsCommand : IRequest<UpdatedTranscriptCalculationsResponse>
{
    public Guid StudentId { get; set; }

    public class UpdateTranscriptCalculationsCommandHandler : IRequestHandler<UpdateTranscriptCalculationsCommand, UpdatedTranscriptCalculationsResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly TranscriptBusinessRules _transcriptBusinessRules;

        public UpdateTranscriptCalculationsCommandHandler(
            IMapper mapper, 
            ITranscriptRepository transcriptRepository,
            ITakenCourseRepository takenCourseRepository,
            IStudentRepository studentRepository,
            IRequiredCourseListRepository requiredCourseListRepository,
            IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
            TranscriptBusinessRules transcriptBusinessRules)
        {
            _mapper = mapper;
            _transcriptRepository = transcriptRepository;
            _takenCourseRepository = takenCourseRepository;
            _studentRepository = studentRepository;
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _transcriptBusinessRules = transcriptBusinessRules;
        }

        public async Task<UpdatedTranscriptCalculationsResponse> Handle(UpdateTranscriptCalculationsCommand request, CancellationToken cancellationToken)
        {
            // Student'ın transcript'ini bul
            Transcript? transcript = await _transcriptRepository.GetAsync(
                predicate: t => t.StudentId == request.StudentId, 
                cancellationToken: cancellationToken);
            await _transcriptBusinessRules.TranscriptShouldExistWhenSelected(transcript);

            // Student'ın aldığı dersleri getir (Course bilgileri ile birlikte)
            var takenCourses = await _takenCourseRepository.GetListAsync(
                predicate: tc => tc.StudentId == request.StudentId,
                include: tc => tc.Include(x => x.Course),
                size: int.MaxValue,
                cancellationToken: cancellationToken);

            // Student'ı getir ve RequiredCourseListId'sini al
            var student = await _studentRepository.GetAsync(
                predicate: s => s.Id == request.StudentId,
                cancellationToken: cancellationToken);

            // Student'ın zorunlu ders listesini getir
            RequiredCourseList? requiredCourseList = null;
            if (student != null)
            {
                requiredCourseList = await _requiredCourseListRepository.GetAsync(
                    predicate: rcl => rcl.Id == student.RequiredCourseListId,
                    cancellationToken: cancellationToken);
            }

            // Zorunlu ders listesindeki dersleri getir (Course bilgileri ile birlikte)
            var requiredCourses = new List<RequiredCourseListCourse>();
            if (requiredCourseList != null)
            {
                var requiredCoursesResult = await _requiredCourseListCourseRepository.GetListAsync(
                    predicate: rclc => rclc.RequiredCourseListId == requiredCourseList.Id,
                    include: rclc => rclc.Include(x => x.Course),
                    size: int.MaxValue,
                    cancellationToken: cancellationToken);
                requiredCourses = requiredCoursesResult.Items.ToList();
            }

            // Hesaplamaları yap
            var totalTakenCredit = takenCourses.Items.Sum(tc => tc.Course.CourseCredit);
            var totalRequiredCredit = requiredCourses.Sum(rc => rc.Course.CourseCredit);
            var requiredCourseCount = requiredCourses.Count;
            
            // Debug için log ekleyelim
            Console.WriteLine($"DEBUG: StudentId = {request.StudentId}");
            Console.WriteLine($"DEBUG: TotalTakenCredit = {totalTakenCredit}");
            Console.WriteLine($"DEBUG: TotalRequiredCredit = {totalRequiredCredit}");
            Console.WriteLine($"DEBUG: RequiredCourseCount = {requiredCourseCount}");
            Console.WriteLine($"DEBUG: TakenCourses Count = {takenCourses.Items.Count}");
            Console.WriteLine($"DEBUG: RequiredCourses Count = {requiredCourses.Count}");
            
            // Tamamlanan zorunlu ders sayısını ve kredisini hesapla
            var requiredCourseIds = requiredCourses.Select(rc => rc.CourseId).ToHashSet();
            var takenCourseIds = takenCourses.Items.Select(tc => tc.CourseId).ToHashSet();
            var completedRequiredCourseIds = requiredCourseIds.Intersect(takenCourseIds).ToHashSet();
            var completedCourseCount = completedRequiredCourseIds.Count;
            
            Console.WriteLine($"DEBUG: RequiredCourseIds = [{string.Join(", ", requiredCourseIds.Take(5))}...] (showing first 5)");
            Console.WriteLine($"DEBUG: TakenCourseIds = [{string.Join(", ", takenCourseIds.Take(5))}...] (showing first 5)");
            Console.WriteLine($"DEBUG: CompletedRequiredCourseIds = [{string.Join(", ", completedRequiredCourseIds)}]");
            Console.WriteLine($"DEBUG: CompletedCourseCount = {completedCourseCount}");
            
            // Sadece tamamlanan zorunlu derslerin kredisini hesapla
            var completedCredit = requiredCourses
                .Where(rc => completedRequiredCourseIds.Contains(rc.CourseId))
                .Sum(rc => rc.Course.CourseCredit);
                
            Console.WriteLine($"DEBUG: CompletedCredit = {completedCredit}");

            // Transcript'i güncelle
            transcript.TotalTakenCredit = totalTakenCredit;
            transcript.TotalRequiredCredit = totalRequiredCredit;
            transcript.RequiredCourseCount = requiredCourseCount;
            transcript.CompletedCourseCount = completedCourseCount;
            transcript.CompletedCredit = completedCredit; // Sadece tamamlanan zorunlu derslerin kredisi
            transcript.RemainingCredit = Math.Max(0, totalRequiredCredit - completedCredit); // Kalan kredi

            await _transcriptRepository.UpdateAsync(transcript!);

            UpdatedTranscriptCalculationsResponse response = _mapper.Map<UpdatedTranscriptCalculationsResponse>(transcript);
            return response;
        }
    }
} 