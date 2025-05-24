using Application.Features.GraduationLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationLists.Commands.Update;

public class UpdateGraduationListCommand : IRequest<UpdatedGraduationListResponse>
{
    public Guid Id { get; set; }
    public string GraduationListNumber { get; set; }
    public Guid AdvisorId { get; set; }
    public Advisor Advisor { get; set; }

    public class UpdateGraduationListCommandHandler : IRequestHandler<UpdateGraduationListCommand, UpdatedGraduationListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationListRepository _graduationListRepository;
        private readonly GraduationListBusinessRules _graduationListBusinessRules;

        public UpdateGraduationListCommandHandler(IMapper mapper, IGraduationListRepository graduationListRepository,
                                         GraduationListBusinessRules graduationListBusinessRules)
        {
            _mapper = mapper;
            _graduationListRepository = graduationListRepository;
            _graduationListBusinessRules = graduationListBusinessRules;
        }

        public async Task<UpdatedGraduationListResponse> Handle(UpdateGraduationListCommand request, CancellationToken cancellationToken)
        {
            GraduationList? graduationList = await _graduationListRepository.GetAsync(predicate: gl => gl.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationListBusinessRules.GraduationListShouldExistWhenSelected(graduationList);
            graduationList = _mapper.Map(request, graduationList);

            await _graduationListRepository.UpdateAsync(graduationList!);

            UpdatedGraduationListResponse response = _mapper.Map<UpdatedGraduationListResponse>(graduationList);
            return response;
        }
    }
}