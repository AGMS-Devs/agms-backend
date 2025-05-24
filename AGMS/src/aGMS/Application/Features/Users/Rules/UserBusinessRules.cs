using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using NArchitecture.Core.Security.Hashing;

namespace Application.Features.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public UserBusinessRules(
        IUserRepository userRepository,
        ILocalizationService localizationService)
    {
        _userRepository = userRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UsersMessages.SectionName);
        throw new BusinessException(message);
    }

    // Genel kurallar
    public async Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserIdShouldBeExistsWhenSelected(Guid id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id);
        if (!doesExist)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            await throwBusinessException(UsersMessages.PasswordDontMatch);
    }

    public async Task UserEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(UsersMessages.UserMailAlreadyExists);
    }

    public async Task UserEmailShouldNotExistsWhenUpdate(Guid id, string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Email == email && u.Id != id);
        if (doesExists)
            await throwBusinessException(UsersMessages.UserMailAlreadyExists);
    }

    public async Task UserTypeShouldBeValid(UserType userType)
    {
        if (!Enum.IsDefined(typeof(UserType), userType))
            await throwBusinessException(UsersMessages.InvalidUserType);
    }

    public async Task UserShouldBeActive(User user)
    {
        if (!user.IsActive)
            await throwBusinessException(UsersMessages.UserIsNotActive);
    }
}
