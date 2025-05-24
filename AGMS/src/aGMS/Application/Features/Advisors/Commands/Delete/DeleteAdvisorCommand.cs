using Application.Features.Advisors.Constants;
using Application.Features.Advisors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Advisors.Commands.Delete;

public class DeleteAdvisorCommand : IRequest<DeletedAdvisorResponse>
{
    public Guid Id { get; set; }

    public class DeleteAdvisorCommandHandler : IRequestHandler<DeleteAdvisorCommand, DeletedAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvisorRepository _advisorRepository;
        private readonly AdvisorBusinessRules _advisorBusinessRules;

        public DeleteAdvisorCommandHandler(IMapper mapper, IAdvisorRepository advisorRepository,
                                         AdvisorBusinessRules advisorBusinessRules)
        {
            _mapper = mapper;
            _advisorRepository = advisorRepository;
            _advisorBusinessRules = advisorBusinessRules;
        }

        public async Task<DeletedAdvisorResponse> Handle(DeleteAdvisorCommand request, CancellationToken cancellationToken)
        {
            Advisor? advisor = await _advisorRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _advisorBusinessRules.AdvisorShouldExistWhenSelected(advisor);

            await _advisorRepository.DeleteAsync(advisor!);

            DeletedAdvisorResponse response = _mapper.Map<DeletedAdvisorResponse>(advisor);
            return response;
        }
    }
}