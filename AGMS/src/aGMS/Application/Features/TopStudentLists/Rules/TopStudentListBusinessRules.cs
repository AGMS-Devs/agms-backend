using Application.Features.TopStudentLists.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Domain.Enums;
using System.Security.Claims;

namespace Application.Features.TopStudentLists.Rules;

public class TopStudentListBusinessRules : BaseBusinessRules
{
    private readonly ITopStudentListRepository _topStudentListRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TopStudentListBusinessRules(
        ITopStudentListRepository topStudentListRepository, 
        IStaffRepository staffRepository,
        ILocalizationService localizationService,
        IHttpContextAccessor httpContextAccessor)
    {
        _topStudentListRepository = topStudentListRepository;
        _staffRepository = staffRepository;
        _localizationService = localizationService;
        _httpContextAccessor = httpContextAccessor;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TopStudentListsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TopStudentListShouldExistWhenSelected(TopStudentList? topStudentList)
    {
        if (topStudentList == null)
            await throwBusinessException(TopStudentListsBusinessMessages.TopStudentListNotExists);
    }

    public async Task TopStudentListIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TopStudentList? topStudentList = await _topStudentListRepository.GetAsync(
            predicate: tsl => tsl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TopStudentListShouldExistWhenSelected(topStudentList);
    }

    public async Task<Guid> GetCurrentUserId()
    {
        // ClaimTypes.NameIdentifier kullan - projede standart bu
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            throw new BusinessException("User authentication required");

        return userId;
    }

    public async Task<Staff> GetCurrentStaff(CancellationToken cancellationToken)
    {
        var currentUserId = await GetCurrentUserId();
        
        var staff = await _staffRepository.GetAsync(
            predicate: s => s.Id == currentUserId,
            cancellationToken: cancellationToken
        );

        if (staff == null)
            throw new BusinessException("Only staff members can access top student lists");

        return staff;
    }

    public async Task ValidateStudentAffairsAccess(TopStudentList topStudentList, CancellationToken cancellationToken)
    {
        var staff = await GetCurrentStaff(cancellationToken);
        var currentUserId = await GetCurrentUserId();

        if (staff.StaffRole != StaffRole.StudentAffairs)
            throw new BusinessException("Only Student Affairs staff can perform this action");

        if (topStudentList.StudentAffairsStaffId != currentUserId)
            throw new BusinessException("You can only access your own assigned lists");
    }

    public async Task ValidateRectorateAccess(TopStudentList topStudentList, CancellationToken cancellationToken)
    {
        var staff = await GetCurrentStaff(cancellationToken);
        var currentUserId = await GetCurrentUserId();

        if (staff.StaffRole != StaffRole.Rectorate)
            throw new BusinessException("Only Rectorate staff can perform this action");

        if (topStudentList.RectorateStaffId != currentUserId)
            throw new BusinessException("You can only access your own assigned lists");

        if (!topStudentList.SendRectorate)
            throw new BusinessException("List must be sent to rectorate before access is allowed");
    }

    public async Task ValidateStudentAffairsApprovalPrerequisites(TopStudentList topStudentList, CancellationToken cancellationToken)
    {
        await ValidateStudentAffairsAccess(topStudentList, cancellationToken);
    }

    public async Task ValidateSendToRectoratePrerequisites(TopStudentList topStudentList, CancellationToken cancellationToken)
    {
        await ValidateStudentAffairsAccess(topStudentList, cancellationToken);

        if (!topStudentList.StudentAffairsApproval)
            throw new BusinessException("Student Affairs approval is required before sending to rectorate");
    }

    public async Task ValidateRectorateApprovalPrerequisites(TopStudentList topStudentList, CancellationToken cancellationToken)
    {
        await ValidateRectorateAccess(topStudentList, cancellationToken);
    }

    public async Task<bool> CanUserAccessTopStudentList(TopStudentList topStudentList, CancellationToken cancellationToken)
    {
        try
        {
            var staff = await GetCurrentStaff(cancellationToken);
            var currentUserId = await GetCurrentUserId();

            return staff.StaffRole switch
            {
                StaffRole.StudentAffairs => topStudentList.StudentAffairsStaffId == currentUserId,
                StaffRole.Rectorate => topStudentList.RectorateStaffId == currentUserId && topStudentList.SendRectorate == true,
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }
}