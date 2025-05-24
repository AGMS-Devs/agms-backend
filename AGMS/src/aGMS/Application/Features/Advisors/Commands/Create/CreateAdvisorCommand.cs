using Application.Features.Advisors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Advisors.Commands.Create;

public class CreateAdvisorCommand : IRequest<CreatedAdvisorResponse>
{

    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }

    public class CreateAdvisorCommandHandler : IRequestHandler<CreateAdvisorCommand, CreatedAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly AdvisorBusinessRules _advisorBusinessRules;

        public CreateAdvisorCommandHandler(IMapper mapper, IAdvisorRepository advisorRepository,
                                         AdvisorBusinessRules advisorBusinessRules)
        {
            _mapper = mapper;
            _advisorRepository = advisorRepository;
            _advisorBusinessRules = advisorBusinessRules;
        }

        public async Task<CreatedAdvisorResponse> Handle(CreateAdvisorCommand request, CancellationToken cancellationToken)
        {
            Advisor advisor = _mapper.Map<Advisor>(request);

            await _advisorRepository.AddAsync(advisor);

            CreatedAdvisorResponse response = _mapper.Map<CreatedAdvisorResponse>(advisor);
            return response;
        }
    }
}