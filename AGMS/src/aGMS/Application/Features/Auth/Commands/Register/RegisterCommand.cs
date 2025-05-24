using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IUserOperationClaimRepository userOperationClaimRepository,
            IOperationClaimRepository operationClaimRepository
        )
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        private UserType DetermineUserType(string email)
        {
            if (email.EndsWith("@std.iyte.edu.tr", StringComparison.OrdinalIgnoreCase))
                return UserType.Student;
            if (email.EndsWith("@iyte.edu.tr", StringComparison.OrdinalIgnoreCase))
                return UserType.Staff;
            return UserType.Student; // Varsayılan olarak öğrenci
        }

        private async Task AssignRoleToUser(User user, UserType userType)
        {
            string roleName = userType switch
            {
                UserType.Student => "Student",
                UserType.Staff => "Staff",
                UserType.Advisor => "Advisor",
                UserType.Admin => "Admin",
                _ => "Student"
            };

            var operationClaim = await _operationClaimRepository.GetAsync(
                predicate: oc => oc.Name == roleName,
                cancellationToken: CancellationToken.None
            );

            if (operationClaim != null)
            {
                var userOperationClaim = new UserOperationClaim
                {
                    UserId = user.Id,
                    OperationClaimId = operationClaim.Id
                };

                await _userOperationClaimRepository.AddAsync(userOperationClaim);
            }
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );

            // Kullanıcı tipini belirle
            var userType = request.UserForRegisterDto.UserType ?? DetermineUserType(request.UserForRegisterDto.Email);

            User newUser = new()
            {
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = request.UserForRegisterDto.Name,
                Surname = request.UserForRegisterDto.Surname,
                PhoneNumber = request.UserForRegisterDto.PhoneNumber,
                UserType = userType,
                IsActive = true
            };

            User createdUser = await _userRepository.AddAsync(newUser);

            // Kullanıcıya rol ata
            await AssignRoleToUser(createdUser, userType);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
                createdUser,
                request.IpAddress
            );
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
