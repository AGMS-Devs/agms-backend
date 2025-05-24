using Application.Features.Rectorates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rectorates.Commands.Update;

public class UpdateRectorateCommand : IRequest<UpdatedRectorateResponse>
{
    public Guid Id { get; set; }
    public Guid StudentAffairId { get; set; }
    public StudentAffair StudentAffair { get; set; }

    public class UpdateRectorateCommandHandler : IRequestHandler<UpdateRectorateCommand, UpdatedRectorateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRectorateRepository _rectorateRepository;
        private readonly RectorateBusinessRules _rectorateBusinessRules;

        public UpdateRectorateCommandHandler(IMapper mapper, IRectorateRepository rectorateRepository,
                                         RectorateBusinessRules rectorateBusinessRules)
        {
            _mapper = mapper;
            _rectorateRepository = rectorateRepository;
            _rectorateBusinessRules = rectorateBusinessRules;
        }

        public async Task<UpdatedRectorateResponse> Handle(UpdateRectorateCommand request, CancellationToken cancellationToken)
        {
            Rectorate? rectorate = await _rectorateRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rectorateBusinessRules.RectorateShouldExistWhenSelected(rectorate);
            rectorate = _mapper.Map(request, rectorate);

            await _rectorateRepository.UpdateAsync(rectorate!);

            UpdatedRectorateResponse response = _mapper.Map<UpdatedRectorateResponse>(rectorate);
            return response;
        }
    }
}