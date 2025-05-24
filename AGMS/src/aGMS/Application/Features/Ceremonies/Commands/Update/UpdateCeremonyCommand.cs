using Application.Features.Ceremonies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Ceremonies.Commands.Update;

public class UpdateCeremonyCommand : IRequest<UpdatedCeremonyResponse>
{
    public Guid Id { get; set; }
    public DateTime CeremonyDate { get; set; }
    public string CeremonyLocation { get; set; }
    public string CeremonyDescription { get; set; }
    public CeremonyStatus CeremonyStatus { get; set; }
    public string AcademicYear { get; set; }
    public Guid StudentAffairsId { get; set; }

    public class UpdateCeremonyCommandHandler : IRequestHandler<UpdateCeremonyCommand, UpdatedCeremonyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly IGraduationProcessRepository _graduationProcessRepository;
        private readonly CeremonyBusinessRules _ceremonyBusinessRules;

        public UpdateCeremonyCommandHandler(IMapper mapper, ICeremonyRepository ceremonyRepository,
                                         IGraduationProcessRepository graduationProcessRepository,
                                         CeremonyBusinessRules ceremonyBusinessRules)
        {
            _mapper = mapper;
            _ceremonyRepository = ceremonyRepository;
            _graduationProcessRepository = graduationProcessRepository;
            _ceremonyBusinessRules = ceremonyBusinessRules;
        }

        public async Task<UpdatedCeremonyResponse> Handle(UpdateCeremonyCommand request, CancellationToken cancellationToken)
        {
            // StudentAffairs kontrolü
            await _ceremonyBusinessRules.StudentAffairShouldExistWhenSelected(request.StudentAffairsId, cancellationToken);

            Ceremony? ceremony = await _ceremonyRepository.GetAsync(
                predicate: c => c.Id == request.Id, 
                include: query => query.Include(c => c.StudentUsers),
                cancellationToken: cancellationToken);
            await _ceremonyBusinessRules.CeremonyShouldExistWhenSelected(ceremony);
            ceremony = _mapper.Map(request, ceremony);

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

            // Mevcut öğrenci listesini temizle ve onaylanan öğrencileri ekle
            ceremony!.StudentUsers.Clear();
            if (approvedGraduationProcesses?.Items != null)
            {
                foreach (var graduationProcess in approvedGraduationProcesses.Items)
                {
                    ceremony.StudentUsers.Add(graduationProcess.StudentUser);
                }
            }

            await _ceremonyRepository.UpdateAsync(ceremony!);

            UpdatedCeremonyResponse response = _mapper.Map<UpdatedCeremonyResponse>(ceremony);
            return response;
        }
    }
}