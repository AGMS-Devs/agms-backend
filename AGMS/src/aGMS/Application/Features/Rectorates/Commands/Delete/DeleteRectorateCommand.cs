using Application.Features.Rectorates.Constants;
using Application.Features.Rectorates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rectorates.Commands.Delete;

public class DeleteRectorateCommand : IRequest<DeletedRectorateResponse>
{
    public Guid Id { get; set; }

    public class DeleteRectorateCommandHandler : IRequestHandler<DeleteRectorateCommand, DeletedRectorateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRectorateRepository _rectorateRepository;
        private readonly RectorateBusinessRules _rectorateBusinessRules;

        public DeleteRectorateCommandHandler(IMapper mapper, IRectorateRepository rectorateRepository,
                                         RectorateBusinessRules rectorateBusinessRules)
        {
            _mapper = mapper;
            _rectorateRepository = rectorateRepository;
            _rectorateBusinessRules = rectorateBusinessRules;
        }

        public async Task<DeletedRectorateResponse> Handle(DeleteRectorateCommand request, CancellationToken cancellationToken)
        {
            Rectorate? rectorate = await _rectorateRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rectorateBusinessRules.RectorateShouldExistWhenSelected(rectorate);

            await _rectorateRepository.DeleteAsync(rectorate!);

            DeletedRectorateResponse response = _mapper.Map<DeletedRectorateResponse>(rectorate);
            return response;
        }
    }
}