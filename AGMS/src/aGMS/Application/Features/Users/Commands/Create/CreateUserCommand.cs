using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Security.Hashing;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<CreatedUserResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public UserType UserType { get; set; }
    public bool IsActive { get; set; } = true;

    public CreateUserCommand()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

    public CreateUserCommand(string name, string surname, string email, string password, string? phoneNumber, UserType userType, bool isActive = true)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        UserType = userType;
        IsActive = isActive;
    }

    public string[] Roles => new[] { Admin, Write, UsersOperationClaims.Create };

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);
            User user = _mapper.Map<User>(request);

            HashingHelper.CreatePasswordHash(
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            User createdUser = await _userRepository.AddAsync(user);

            CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createdUser);
            return response;
        }
    }
}
