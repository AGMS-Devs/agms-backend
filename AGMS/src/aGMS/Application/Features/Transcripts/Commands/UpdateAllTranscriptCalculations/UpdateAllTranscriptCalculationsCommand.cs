using Application.Features.Transcripts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transcripts.Commands.UpdateAllTranscriptCalculations;

public class UpdateAllTranscriptCalculationsCommand : IRequest<UpdatedAllTranscriptCalculationsResponse>
{
    public class UpdateAllTranscriptCalculationsCommandHandler : IRequestHandler<UpdateAllTranscriptCalculationsCommand, UpdatedAllTranscriptCalculationsResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITranscriptRepository _transcriptRepository;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly TranscriptBusinessRules _transcriptBusinessRules;

        public UpdateAllTranscriptCalculationsCommandHandler(
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

        public async Task<UpdatedAllTranscriptCalculationsResponse> Handle(UpdateAllTranscriptCalculationsCommand request, CancellationToken cancellationToken)
        {
            // Tüm transcript'leri getir
            var allTranscripts = await _transcriptRepository.GetListAsync(
                size: int.MaxValue,
                cancellationToken: cancellationToken);

            var updatedCount = 0;
            var failedCount = 0;
            var successfulStudents = new List<Guid>();

            foreach (var transcript in allTranscripts.Items)
            {
                try
                {
                    // Her öğrenci için hesaplamaları yap
                    await UpdateTranscriptCalculationsForStudent(transcript, cancellationToken);
                    updatedCount++;
                    successfulStudents.Add(transcript.StudentId);
                }
                catch (Exception ex)
                {
                    failedCount++;
                    // Log hatayı ama devam et
                    Console.WriteLine($"HATA: StudentId {transcript.StudentId} için transcript güncellenirken hata: {ex.Message}");
                }
            }

            var response = new UpdatedAllTranscriptCalculationsResponse
            {
                TotalProcessed = allTranscripts.Items.Count,
                SuccessfullyUpdated = updatedCount,
                Failed = failedCount,
                UpdatedStudentIds = successfulStudents,
                UpdatedDate = DateTime.Now
            };

            return response;
        }

        private async Task UpdateTranscriptCalculationsForStudent(Transcript transcript, CancellationToken cancellationToken)
        {
            // Student'ın aldığı dersleri getir (Course bilgileri ile birlikte)
            var takenCourses = await _takenCourseRepository.GetListAsync(
                predicate: tc => tc.StudentId == transcript.StudentId,
                include: tc => tc.Include(x => x.Course),
                size: int.MaxValue,
                cancellationToken: cancellationToken);

            // Student'ı getir ve RequiredCourseListId'sini al
            var student = await _studentRepository.GetAsync(
                predicate: s => s.Id == transcript.StudentId,
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
            
            // Tamamlanan zorunlu ders sayısını ve kredisini hesapla
            var requiredCourseIds = requiredCourses.Select(rc => rc.CourseId).ToHashSet();
            var takenCourseIds = takenCourses.Items.Select(tc => tc.CourseId).ToHashSet();
            var completedRequiredCourseIds = requiredCourseIds.Intersect(takenCourseIds).ToHashSet();
            var completedCourseCount = completedRequiredCourseIds.Count;
            
            // Sadece tamamlanan zorunlu derslerin kredisini hesapla
            var completedCredit = requiredCourses
                .Where(rc => completedRequiredCourseIds.Contains(rc.CourseId))
                .Sum(rc => rc.Course.CourseCredit);

            // Transcript'i güncelle
            transcript.TotalTakenCredit = totalTakenCredit;
            transcript.TotalRequiredCredit = totalRequiredCredit;
            transcript.RequiredCourseCount = requiredCourseCount;
            transcript.CompletedCourseCount = completedCourseCount;
            transcript.CompletedCredit = completedCredit;
            transcript.RemainingCredit = Math.Max(0, totalRequiredCredit - completedCredit);

            await _transcriptRepository.UpdateAsync(transcript);
        }
    }
} 