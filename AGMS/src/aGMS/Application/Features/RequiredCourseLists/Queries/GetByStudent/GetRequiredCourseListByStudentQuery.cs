using Application.Features.RequiredCourseLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RequiredCourseLists.Queries.GetByStudent;

public class GetRequiredCourseListByStudentQuery : IRequest<GetRequiredCourseListByStudentResponse>
{
    public Guid StudentId { get; set; }

    public class GetRequiredCourseListByStudentQueryHandler : IRequestHandler<GetRequiredCourseListByStudentQuery, GetRequiredCourseListByStudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRequiredCourseListRepository _requiredCourseListRepository;
        private readonly IRequiredCourseListCourseRepository _requiredCourseListCourseRepository;
        private readonly IMapper _mapper;
        private readonly RequiredCourseListBusinessRules _requiredCourseListBusinessRules;

        public GetRequiredCourseListByStudentQueryHandler(
            IStudentRepository studentRepository,
            IRequiredCourseListRepository requiredCourseListRepository,
            IRequiredCourseListCourseRepository requiredCourseListCourseRepository,
            IMapper mapper,
            RequiredCourseListBusinessRules requiredCourseListBusinessRules)
        {
            _studentRepository = studentRepository;
            _requiredCourseListRepository = requiredCourseListRepository;
            _requiredCourseListCourseRepository = requiredCourseListCourseRepository;
            _mapper = mapper;
            _requiredCourseListBusinessRules = requiredCourseListBusinessRules;
        }

        public async Task<GetRequiredCourseListByStudentResponse> Handle(GetRequiredCourseListByStudentQuery request, CancellationToken cancellationToken)
        {
            // Önce Student'ı al ve RequiredCourseListId'sini bul
            var student = await _studentRepository.GetAsync(
                predicate: s => s.Id == request.StudentId,
                cancellationToken: cancellationToken
            );

            if (student == null)
                throw new Exception("Student not found");

            // Student'ın RequiredCourseListId'sini kullanarak RequiredCourseList'i al
            RequiredCourseList? requiredCourseList = await _requiredCourseListRepository.GetAsync(
                predicate: rcl => rcl.Id == student.RequiredCourseListId,
                cancellationToken: cancellationToken
            );

            await _requiredCourseListBusinessRules.RequiredCourseListShouldExistWhenSelected(requiredCourseList);

            var requiredCourseListCourses = await _requiredCourseListCourseRepository.GetListAsync(
                predicate: rc => rc.RequiredCourseListId == requiredCourseList.Id,
                include: query => query.Include(rc => rc.Course),
                orderBy: query => query.OrderBy(rc => rc.Course.CourseCode),
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            var courses = requiredCourseListCourses.Items
                .Select(rc => rc.Course)
                .ToList();

            return new GetRequiredCourseListByStudentResponse
            {
                StudentId = request.StudentId,
                Name = requiredCourseList.Name,
                Description = requiredCourseList.Description,
                RequiredCourses = _mapper.Map<List<RequiredCourseDto>>(courses)
            };
        }
    }
} 