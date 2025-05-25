using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Students.Queries.GetStudentsByFaculty;

public class GetStudentsByFacultyQuery : IRequest<GetListResponse<GetStudentsByFacultyListItemDto>>
{
    public Guid FacultyId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetStudentsByFacultyQueryHandler : IRequestHandler<GetStudentsByFacultyQuery, GetListResponse<GetStudentsByFacultyListItemDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyDeansOfficeRepository _facultyRepository;
        private readonly IMapper _mapper;

        public GetStudentsByFacultyQueryHandler(
            IStudentRepository studentRepository,
            IFacultyDeansOfficeRepository facultyRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetStudentsByFacultyListItemDto>> Handle(GetStudentsByFacultyQuery request, CancellationToken cancellationToken)
        {
            // First get the faculty with its departments
            var faculty = await _facultyRepository.GetAsync(
                predicate: f => f.Id == request.FacultyId,
                include: f => f.Include(x => x.Departments),
                cancellationToken: cancellationToken
            );

            if (faculty == null)
                throw new Exception("Faculty not found");

            // Get department IDs
            var departmentIds = faculty.Departments.Select(d => d.Id).ToList();

            // Then get all students from these departments
            IPaginate<Student> students = await _studentRepository.GetListAsync(
                predicate: s => departmentIds.Contains(s.DepartmentId),
                include: s => s
                    .Include(x => x.User)
                    .Include(x => x.Department)
                    .Include(x => x.AssignedAdvisor)
                        .ThenInclude(a => a.User),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetStudentsByFacultyListItemDto> response = _mapper.Map<GetListResponse<GetStudentsByFacultyListItemDto>>(students);

            // Enrich the response with additional data
            foreach (var item in response.Items)
            {
                var student = students.Items.First(s => s.Id == item.Id);
                if (student.AssignedAdvisor?.User != null)
                {
                    item.AdvisorName = student.AssignedAdvisor.User.Name;
                    item.AdvisorSurname = student.AssignedAdvisor.User.Surname;
                }
                if (student.Department != null)
                {
                    item.DepartmentName = student.Department.DepartmentName;
                }
                if (student.User != null)
                {
                    item.Name = student.User.Name;
                    item.Surname = student.User.Surname;
                }
            }

            return response;
        }
    }
} 