using Application.Features.Advisors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Advisors.Queries.GetById;

public class GetByIdAdvisorQuery : IRequest<GetByIdAdvisorResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdvisorQueryHandler : IRequestHandler<GetByIdAdvisorQuery, GetByIdAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly AdvisorBusinessRules _advisorBusinessRules;

        public GetByIdAdvisorQueryHandler(
            IMapper mapper, 
            IAdvisorRepository advisorRepository, 
            AdvisorBusinessRules advisorBusinessRules)
        {
            _mapper = mapper;
            _advisorRepository = advisorRepository;
            _advisorBusinessRules = advisorBusinessRules;
        }

        public async Task<GetByIdAdvisorResponse> Handle(GetByIdAdvisorQuery request, CancellationToken cancellationToken)
        {
            Advisor? advisor = await _advisorRepository.GetAsync(
                predicate: a => a.Id == request.Id,
                include: query => query
                    .Include(a => a.User)
                    .Include(a => a.Department),
                cancellationToken: cancellationToken
            );

            await _advisorBusinessRules.AdvisorShouldExistWhenSelected(advisor);

            GetByIdAdvisorResponse response = _mapper.Map<GetByIdAdvisorResponse>(advisor);
            
            if (advisor.User != null)
            {
                response.Name = advisor.User.Name;
                response.Surname = advisor.User.Surname;
            }

            if (advisor.Department != null)
            {
                response.DepartmentName = advisor.Department.DepartmentName;
            }

            return response;
        }
    }
}