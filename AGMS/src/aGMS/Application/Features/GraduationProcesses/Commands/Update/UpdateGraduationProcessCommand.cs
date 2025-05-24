using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationProcesses.Commands.Update;

public class UpdateGraduationProcessCommand : IRequest<UpdatedGraduationProcessResponse>
{
    public Guid Id { get; set; }
    public bool AdvisorApproved { get; set; }
    public DateTime AdvisorApprovedDate { get; set; }
    public bool DepartmentSecretaryApproved { get; set; }
    public DateTime DepartmentSecretaryApprovedDate { get; set; }
    public bool FacultyDeansOfficeApproved { get; set; }
    public DateTime FacultyDeansOfficeApprovedDate { get; set; }
    public bool StudentAffairsApproved { get; set; }
    public DateTime StudentAffairsApprovedDate { get; set; }
    public Guid StudentId { get; set; }
    public Guid GraduationListId { get; set; }

    public class UpdateGraduationProcessCommandHandler : IRequestHandler<UpdateGraduationProcessCommand, UpdatedGraduationProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;

        public UpdateGraduationProcessCommandHandler(IMapper mapper, IGraduationProcessRepository graduationProcessRepository,
                                         GraduationProcessBusinessRules graduationProcessBusinessRules)
        {
            _mapper = mapper;
            _graduationProcessRepository = graduationProcessRepository;
            _graduationProcessBusinessRules = graduationProcessBusinessRules;
        }

        public async Task<UpdatedGraduationProcessResponse> Handle(UpdateGraduationProcessCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(predicate: gp => gp.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationProcessBusinessRules.GraduationProcessShouldExistWhenSelected(graduationProcess);
            graduationProcess = _mapper.Map(request, graduationProcess);

            await _graduationProcessRepository.UpdateAsync(graduationProcess!);

            UpdatedGraduationProcessResponse response = _mapper.Map<UpdatedGraduationProcessResponse>(graduationProcess);
            return response;
        }
    }
}