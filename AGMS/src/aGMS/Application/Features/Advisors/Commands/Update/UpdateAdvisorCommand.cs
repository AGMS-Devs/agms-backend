using Application.Features.Advisors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Advisors.Commands.Update;

public class UpdateAdvisorCommand : IRequest<UpdatedAdvisorResponse>
{
    public Guid Id { get; set; }
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }

    public class UpdateAdvisorCommandHandler : IRequestHandler<UpdateAdvisorCommand, UpdatedAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly AdvisorBusinessRules _advisorBusinessRules;

        public UpdateAdvisorCommandHandler(IMapper mapper, IAdvisorRepository advisorRepository,
                                         AdvisorBusinessRules advisorBusinessRules)
        {
            _mapper = mapper;
            _advisorRepository = advisorRepository;
            _advisorBusinessRules = advisorBusinessRules;
        }

        public async Task<UpdatedAdvisorResponse> Handle(UpdateAdvisorCommand request, CancellationToken cancellationToken)
        {
            Advisor? advisor = await _advisorRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _advisorBusinessRules.AdvisorShouldExistWhenSelected(advisor);
            advisor = _mapper.Map(request, advisor);

            await _advisorRepository.UpdateAsync(advisor!);

            UpdatedAdvisorResponse response = _mapper.Map<UpdatedAdvisorResponse>(advisor);
            return response;
        }
    }
}