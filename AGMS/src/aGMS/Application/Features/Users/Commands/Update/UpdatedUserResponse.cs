using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Update;

public class UpdatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public UserType UserType { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public string Password { get; set; }

    public UpdatedUserResponse()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Email = string.Empty;
        UserType = UserType.Student;
        PhoneNumber = string.Empty;
        IsActive = true;

    }

    public UpdatedUserResponse(Guid id, string name, string surname, string email, UserType userType, string phoneNumber, bool isActive, string password)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        UserType = userType;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
        Password = password;
    }
}
