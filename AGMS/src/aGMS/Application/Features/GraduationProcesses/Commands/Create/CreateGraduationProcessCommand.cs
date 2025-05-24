using Application.Features.GraduationProcesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GraduationProcesses.Commands.Create;

public class CreateGraduationProcessCommand : IRequest<CreatedGraduationProcessResponse>
{
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

    public class CreateGraduationProcessCommandHandler : IRequestHandler<CreateGraduationProcessCommand, CreatedGraduationProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly GraduationProcessBusinessRules _graduationProcessBusinessRules;

        public CreateGraduationProcessCommandHandler(IMapper mapper, IGraduationProcessRepository graduationProcessRepository,
                                         GraduationProcessBusinessRules graduationProcessBusinessRules)
        {
            _mapper = mapper;
            _graduationProcessRepository = graduationProcessRepository;
            _graduationProcessBusinessRules = graduationProcessBusinessRules;
        }

        public async Task<CreatedGraduationProcessResponse> Handle(CreateGraduationProcessCommand request, CancellationToken cancellationToken)
        {
            GraduationProcess graduationProcess = _mapper.Map<GraduationProcess>(request);

            await _graduationProcessRepository.AddAsync(graduationProcess);

            CreatedGraduationProcessResponse response = _mapper.Map<CreatedGraduationProcessResponse>(graduationProcess);
            return response;
        }
    }
}