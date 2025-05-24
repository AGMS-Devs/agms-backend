using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Ceremonies.Commands.Create;

public class CreateCeremonyCommand : IRequest<CreatedCeremonyResponse>
{
    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; }
    public string CeremonyDescription { get; set; }
    public CeremonyStatus CeremonyStatus { get; set; }
    public string AcademicYear { get; set; }
    public Guid StudentAffairsId { get; set; }

    public class CreateCeremonyCommandHandler : IRequestHandler<CreateCeremonyCommand, CreatedCeremonyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly CeremonyBusinessRules _ceremonyBusinessRules;

        public CreateCeremonyCommandHandler(IMapper mapper, ICeremonyRepository ceremonyRepository,
                                         IGraduationProcessRepository graduationProcessRepository,
                                         CeremonyBusinessRules ceremonyBusinessRules)
        {
            _mapper = mapper;
            _ceremonyRepository = ceremonyRepository;
            _graduationProcessRepository = graduationProcessRepository;
            _ceremonyBusinessRules = ceremonyBusinessRules;
        }

        public async Task<CreatedCeremonyResponse> Handle(CreateCeremonyCommand request, CancellationToken cancellationToken)
        {
            // StudentAffairs kontrolü
            await _ceremonyBusinessRules.StudentAffairShouldExistWhenSelected(request.StudentAffairsId, cancellationToken);

            Ceremony ceremony = _mapper.Map<Ceremony>(request);

            await _ceremonyRepository.AddAsync(ceremony);

            // Mezuniyet süreci tamamlanmış (tüm onayları alınmış) öğrencileri bulun
            var approvedGraduationProcesses = await _graduationProcessRepository.GetListAsync(
                predicate: gp => gp.AdvisorApproved == true &&
                               gp.DepartmentSecretaryApproved == true &&
                               gp.FacultyDeansOfficeApproved == true &&
                               gp.StudentAffairsApproved == true,
                include: query => query.Include(gp => gp.StudentUser),
                enableTracking: true,
                cancellationToken: cancellationToken
            );

            // Onaylanan öğrencileri ceremony'e ekle
            if (approvedGraduationProcesses?.Items != null)
            {
                foreach (var graduationProcess in approvedGraduationProcesses.Items)
                {
                    ceremony.StudentUsers.Add(graduationProcess.StudentUser);
                }
            }

            await _ceremonyRepository.UpdateAsync(ceremony);

            CreatedCeremonyResponse response = _mapper.Map<CreatedCeremonyResponse>(ceremony);
            return response;
        }
    }
}