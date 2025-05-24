using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Students.Queries.GetStudentsByDepartment;

public class GetStudentsByDepartmentQuery : IRequest<GetListResponse<GetStudentsByDepartmentListItemDto>>
{
    public Guid DepartmentId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetStudentsByDepartmentQueryHandler : IRequestHandler<GetStudentsByDepartmentQuery, GetListResponse<GetStudentsByDepartmentListItemDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentsByDepartmentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetStudentsByDepartmentListItemDto>> Handle(GetStudentsByDepartmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Student> students = await _studentRepository.GetListAsync(
                predicate: s => s.DepartmentId == request.DepartmentId,
                include: s => s.Include(x => x.User)
                             .Include(x => x.Department)
                             .Include(x => x.AssignedAdvisor)
                             .ThenInclude(a => a.User)
                             .Include(s => s.RequiredCourseList),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetStudentsByDepartmentListItemDto> response = _mapper.Map<GetListResponse<GetStudentsByDepartmentListItemDto>>(students);
            return response;
        }
    }
} 