using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequiredCourseLists.Queries.GetUncompletedCourses;

public class GetUncompletedCoursesQuery : IRequest<GetUncompletedCoursesResponse>
{
    public Guid StudentId { get; set; }

    public class GetUncompletedCoursesQueryHandler : IRequestHandler<GetUncompletedCoursesQuery, GetUncompletedCoursesResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly ITakenCourseRepository _takenCourseRepository;
        private readonly IMapper _mapper;
        private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

        public GetUncompletedCoursesQueryHandler(
            IStudentRepository studentRepository,
            IRequiredCourseListRepository requiredCourseListRepository,
            IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
            ITakenCourseRepository takenCourseRepository,
            IMapper mapper,
            RequiredCourseListBusinessRules requiredCourseListBusinessRules)
        {
            _studentRepository = studentRepository;
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _takenCourseRepository = takenCourseRepository;
            _mapper = mapper;
            _requiredCourseListBusinessRules = requiredCourseListBusinessRules;
        }

        public async Task<GetUncompletedCoursesResponse> Handle(GetUncompletedCoursesQuery request, CancellationToken cancellationToken)
        {
            // Öğrenciyi al ve RequiredCourseListId'sini bul
            var student = await _studentRepository.GetAsync(
                predicate: s => s.Id == request.StudentId,
                cancellationToken: cancellationToken
            );

            if (student == null)
                throw new Exception("Student not found");

            // Öğrencinin zorunlu ders listesini al
            RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(
                predicate: rcl => rcl.Id == student.RequiredCourseListId,
                cancellationToken: cancellationToken
            );

            await _requiredCourseListBusinessRules.RequiredCourseListShouldExistWhenSelected(requiredCourseList);

            // Öğrencinin zorunlu derslerini al
            var requiredCourseListCourses = await _requiredCourseListCourseRepository.GetListAsync(
                predicate: rc => rc.RequiredCourseListId == requiredCourseList.Id,
                include: query => query.Include(rc => rc.Course),
                orderBy: query => query.OrderBy(rc => rc.Course.CourseCode),
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            // Öğrencinin aldığı dersleri al
            var takenCourses = await _takenCourseRepository.GetListAsync(
                predicate: tc => tc.StudentId == request.StudentId,
                include: query => query.Include(tc => tc.Course),
                orderBy: query => query.OrderByDescending(tc => tc.TakenDate),
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            // Debug için log ekleyelim
            Console.WriteLine($"DEBUG GetUncompleted: StudentId = {request.StudentId}");
            Console.WriteLine($"DEBUG GetUncompleted: RequiredCourses Count = {requiredCourseListCourses.Items.Count}");
            Console.WriteLine($"DEBUG GetUncompleted: TakenCourses Count = {takenCourses.Items.Count}");
            
            var requiredCoursesDebug = requiredCourseListCourses.Items.Select(rc => rc.Course.CourseCode).ToList();
            var takenCoursesDebug = takenCourses.Items.Select(tc => tc.Course.CourseCode).ToList();
            
            Console.WriteLine($"DEBUG GetUncompleted: Required Courses = [{string.Join(", ", requiredCoursesDebug)}]");
            Console.WriteLine($"DEBUG GetUncompleted: Taken Courses = [{string.Join(", ", takenCoursesDebug)}]");

            // Alınmamış dersleri bul
            var uncompletedCourses = requiredCourseListCourses.Items
                .Select(rc => rc.Course)
                .Where(c => !takenCourses.Items.Any(tc => tc.CourseId == c.Id))
                .ToList();
                
            Console.WriteLine($"DEBUG GetUncompleted: Uncompleted Count = {uncompletedCourses.Count}");

            return new GetUncompletedCoursesResponse
            {
                StudentId = request.StudentId,
                UncompletedCourses = _mapper.Map<List<UncompletedCourseDto>>(uncompletedCourses)
            };
        }
    }
} 