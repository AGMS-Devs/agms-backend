using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Queries.GetAllStudents;

public class GetAllStudentsQuery : IRequest<List<GetAllStudentsListItemDto>>
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<GetAllStudentsListItemDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllStudentsListItemDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetListAsync(
                include: query => query
                    .Include(s => s.User)
                    .Include(s => s.Department)
                    .Include(s => s.AssignedAdvisor)
                        .ThenInclude(a => a.User)
                    .Include(s => s.RequiredCourseList),
                size: int.MaxValue, // Tüm kayıtları getir
                index: 0,
                cancellationToken: cancellationToken
            );

            List<GetAllStudentsListItemDto> response = _mapper.Map<List<GetAllStudentsListItemDto>>(students.Items);
            return response;
        }
    }
} 