using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentQuery : IRequest<GetListResponse<GetListStudentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, GetListResponse<GetListStudentListItemDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetListStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentListItemDto>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Student> students = await _studentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query
                    .Include(s => s.User)
                    .Include(s => s.Department)
                    .Include(s => s.AssignedAdvisor)
                        .ThenInclude(a => a.User)
                    .Include(s => s.RequiredCourseList),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentListItemDto> response = _mapper.Map<GetListResponse<GetListStudentListItemDto>>(students);

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