using Application.Features.GraduationProcesses.Constants;
using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationProcesses.Commands.Delete;

public class DeleteGraduationProcessCommand : IRequest<DeletedGraduationProcessResponse>
{
    public Guid Id { get; set; }

    public class DeleteGraduationProcessCommandHandler : IRequestHandler<DeleteGraduationProcessCommand, DeletedGraduationProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;

        public DeleteGraduationProcessCommandHandler(IMapper mapper, IGraduationProcessRepository graduationProcessRepository,
                                         GraduationProcessBusinessRules graduationProcessBusinessRules)
        {
            _mapper = mapper;
            _graduationProcessRepository = graduationProcessRepository;
            _graduationProcessBusinessRules = graduationProcessBusinessRules;
        }

        public async Task<DeletedGraduationProcessResponse> Handle(DeleteGraduationProcessCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(predicate: gp => gp.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);

            await _graduationProcessRepository.DeleteAsync(graduationProcess!);

            DeletedGraduationProcessResponse response = _mapper.Map<DeletedGraduationProcessResponse>(graduationProcess);
            return response;
        }
    }
}