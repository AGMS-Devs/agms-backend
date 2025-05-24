using Application.Features.Ceremonies.Constants;
using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Ceremonies.Commands.Delete;

public class DeleteCeremonyCommand : IRequest<DeletedCeremonyResponse>
{
    public Guid Id { get; set; }

    public class DeleteCeremonyCommandHandler : IRequestHandler<DeleteCeremonyCommand, DeletedCeremonyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly CeremonyBusinessRules _ceremonyBusinessRules;

        public DeleteCeremonyCommandHandler(IMapper mapper, ICeremonyRepository ceremonyRepository,
                                         CeremonyBusinessRules ceremonyBusinessRules)
        {
            _mapper = mapper;
            _ceremonyRepository = ceremonyRepository;
            _ceremonyBusinessRules = ceremonyBusinessRules;
        }

        public async Task<DeletedCeremonyResponse> Handle(DeleteCeremonyCommand request, CancellationToken cancellationToken)
        {
            Ceremony? ceremony = await _ceremonyRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _ceremonyBusinessRules.CeremonyShouldExistWhenSelected(ceremony);

            await _ceremonyRepository.DeleteAsync(ceremony!);

            DeletedCeremonyResponse response = _mapper.Map<DeletedCeremonyResponse>(ceremony);
            return response;
        }
    }
}