using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public UserType UserType { get; set; }
    public StaffRole? StaffRole { get; set; }
    public bool IsActive { get; set; }

    public GetByIdUserResponse()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Email = string.Empty;
    }

    public GetByIdUserResponse(Guid id, string name, string surname, string email, string? phoneNumber, UserType userType, StaffRole? staffRole, bool isActive)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        UserType = userType;
        StaffRole = staffRole;
        IsActive = isActive;
    }
}
