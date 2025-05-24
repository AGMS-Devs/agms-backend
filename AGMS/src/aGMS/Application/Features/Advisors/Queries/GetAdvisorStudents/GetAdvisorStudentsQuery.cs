using Application.Features.Advisors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using Microsoft.Extensions.Logging;

namespace Application.Features.Advisors.Queries.GetAdvisorStudents;

public class GetAdvisorStudentsQuery : IRequest<GetListResponse<GetAdvisorStudentsResponse>>
{
    public Guid AdvisorId { get; set; }
    public StudentStatus? StudentStatusFilter { get; set; }
    public GraduationStatus? GraduationStatusFilter { get; set; }

    public class GetAdvisorStudentsQueryHandler : IRequestHandler<GetAdvisorStudentsQuery, GetListResponse<GetAdvisorStudentsResponse>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly AdvisorBusinessRules _advisorBusinessRules;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAdvisorStudentsQueryHandler> _logger;

        public GetAdvisorStudentsQueryHandler(
            IStudentRepository studentRepository,
            IAdvisorRepository advisorRepository,
            AdvisorBusinessRules advisorBusinessRules,
            IMapper mapper,
            ILogger<GetAdvisorStudentsQueryHandler> logger)
        {
            _studentRepository = studentRepository;
            _advisorRepository = advisorRepository;
            _advisorBusinessRules = advisorBusinessRules;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetListResponse<GetAdvisorStudentsResponse>> Handle(GetAdvisorStudentsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting students for advisor: {request.AdvisorId}");
            _logger.LogInformation($"Filters - StudentStatus: {request.StudentStatusFilter}, GraduationStatus: {request.GraduationStatusFilter}");

            // Danışmanın varlığını kontrol et
            Advisor? advisor = await _advisorRepository.GetAsync(
                predicate: a => a.Id == request.AdvisorId,
                cancellationToken: cancellationToken
            );
            await _advisorBusinessRules.AdvisorShouldExistWhenSelected(advisor);

            // Öğrencileri filtrele ve getir
            var query = _studentRepository.Query()
                .Include(s => s.User)
                .Include(s => s.Department)
                .Where(s => s.AssignedAdvisorId == request.AdvisorId);

            // StudentStatus filtresi
            if (request.StudentStatusFilter.HasValue)
            {
                var statusValue = request.StudentStatusFilter.Value;
                _logger.LogInformation($"Filtering by StudentStatus: {statusValue} ({(int)statusValue})");
                query = query.Where(s => s.StudentStatus == statusValue);
            }

            // GraduationStatus filtresi
            if (request.GraduationStatusFilter.HasValue)
            {
                var gradValue = request.GraduationStatusFilter.Value;
                _logger.LogInformation($"Filtering by GraduationStatus: {gradValue} ({(int)gradValue})");
                query = query.Where(s => s.GraduationStatus == gradValue);
            }

            // SQL sorgusunu logla
            var sql = query.ToQueryString();
            _logger.LogInformation($"Generated SQL: {sql}");

            IPaginate<Student> students = await query.ToPaginateAsync(
                index: 0,
                size: int.MaxValue,
                cancellationToken: cancellationToken
            );

            _logger.LogInformation($"Found {students.Items.Count} students");

            GetListResponse<GetAdvisorStudentsResponse> response = _mapper.Map<GetListResponse<GetAdvisorStudentsResponse>>(students);

            // İlişkili verileri manuel olarak map et
            foreach (var item in response.Items)
            {
                var student = students.Items.First(s => s.Id == item.Id);
                if (student.User != null)
                {
                    item.Name = student.User.Name;
                    item.Surname = student.User.Surname;
                }
                if (student.Department != null)
                {
                    item.DepartmentName = student.Department.DepartmentName;
                }
            }

            return response;
        }
    }
} 