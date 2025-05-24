using Application.Features.GraduationLists.Constants;
using Application.Features.GraduationLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationLists.Commands.Delete;

public class DeleteGraduationListCommand : IRequest<DeletedGraduationListResponse>
{
    public Guid Id { get; set; }

    public class DeleteGraduationListCommandHandler : IRequestHandler<DeleteGraduationListCommand, DeletedGraduationListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationListRepository _graduationListRepository;
        private readonly GraduationListBusinessRules _graduationListBusinessRules;

        public DeleteGraduationListCommandHandler(IMapper mapper, IGraduationListRepository graduationListRepository,
                                         GraduationListBusinessRules graduationListBusinessRules)
        {
            _mapper = mapper;
            _graduationListRepository = graduationListRepository;
            _graduationListBusinessRules = graduationListBusinessRules;
        }

        public async Task<DeletedGraduationListResponse> Handle(DeleteGraduationListCommand request, CancellationToken cancellationToken)
        {
            GraduationList? graduationList = await _graduationListRepository.GetAsync(predicate: gl => gl.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationListBusinessRules.GraduationListShouldExistWhenSelected(graduationList);

            await _graduationListRepository.DeleteAsync(graduationList!);

            DeletedGraduationListResponse response = _mapper.Map<DeletedGraduationListResponse>(graduationList);
            return response;
        }
    }
}