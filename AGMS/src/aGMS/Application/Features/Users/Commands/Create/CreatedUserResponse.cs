using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserType UserType { get; set; }
    public bool IsActive { get; set; }

    public CreatedUserResponse()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Email = string.Empty;
    }

    public CreatedUserResponse(Guid id, string name, string surname, string email, string? phoneNumber, UserType userType, bool isActive)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        UserType = userType;
        IsActive = isActive;
    }
}
