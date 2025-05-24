using Application.Features.GraduationProcesses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Domain.Enums;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GraduationProcesses.Rules;

public class GraduationProcessBusinessRules : BaseBusinessRules
{
    private readonly IGraduationProcessRepository _graduationProcessRepository;
    private readonly IAdvisorRepository _advisorRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ILocalizationService _localizationService;

    public GraduationProcessBusinessRules(
        IGraduationProcessRepository graduationProcessRepository,
        IAdvisorRepository advisorRepository,
        IStaffRepository staffRepository,
        IStudentRepository studentRepository,
        ILocalizationService localizationService)
    {
        _graduationProcessRepository = graduationProcessRepository;
        _advisorRepository = advisorRepository;
        _staffRepository = staffRepository;
        _studentRepository = studentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GraduationProcessesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GraduationProcessShouldExistWhenSelected(GraduationProcess? graduationProcess)
    {
        if (graduationProcess == null)
            await throwBusinessException(GraduationProcessesBusinessMessages.GraduationProcessNotExists);
    }

    public async Task GraduationProcessIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        GraduationProcess? graduationProcess = await _graduationProcessRepository.GetAsync(
            predicate: gp => gp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GraduationProcessShouldExistWhenSelected(graduationProcess);
    }

    public async Task UserShouldBeAuthorizedForAdvisorApproval(GraduationProcess graduationProcess, ClaimsPrincipal user)
    {
        string? userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            throw new AuthorizationException("User not found");

        // Advisor kontrolü
        Advisor? advisor = await _advisorRepository.GetAsync(
            predicate: a => a.Id == userId,
            include: a => a.Include(x => x.GraduationList),
            cancellationToken: default);

        if (advisor == null)
            throw new AuthorizationException("Only advisors can approve graduation processes");

        // Bu advisor'ın graduation process'i onaylayıp onaylayamayacağını kontrol et
        if (advisor.GraduationList == null)
            throw new AuthorizationException("Advisor does not have a graduation list assigned");

        bool isAuthorized = advisor.GraduationList.Id == graduationProcess.GraduationListId;
        if (!isAuthorized)
            throw new AuthorizationException("You are not authorized to approve this graduation process");
    }

    public async Task UserShouldBeAuthorizedForDepartmentSecretaryApproval(GraduationProcess graduationProcess, ClaimsPrincipal user)
    {
        string? userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            throw new AuthorizationException("User not found");

        // Staff kontrolü - DepartmentSecretary rolünde olmalı
        Staff? staff = await _staffRepository.GetAsync(
            predicate: s => s.Id == userId && s.StaffRole == StaffRole.DepartmentSecretary,
            cancellationToken: default);

        if (staff == null)
            throw new AuthorizationException("Only Department Secretary staff can perform this approval");
    }

    public async Task UserShouldBeAuthorizedForFacultyDeansOfficeApproval(GraduationProcess graduationProcess, ClaimsPrincipal user)
    {
        string? userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            throw new AuthorizationException("User not found");

        // Staff kontrolü - FacultyDeansOffice rolünde olmalı
        Staff? staff = await _staffRepository.GetAsync(
            predicate: s => s.Id == userId && s.StaffRole == StaffRole.FacultyDeansOffice,
            cancellationToken: default);

        if (staff == null)
            throw new AuthorizationException("Only Faculty Deans Office staff can perform this approval");
    }

    public async Task UserShouldBeAuthorizedForStudentAffairsApproval(GraduationProcess graduationProcess, ClaimsPrincipal user)
    {
        string? userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            throw new AuthorizationException("User not found");

        // Staff kontrolü - StudentAffairs rolünde olmalı
        Staff? staff = await _staffRepository.GetAsync(
            predicate: s => s.Id == userId && s.StaffRole == StaffRole.StudentAffairs,
            cancellationToken: default);

        if (staff == null)
            throw new AuthorizationException("Only Student Affairs staff can perform this approval");
    }
}