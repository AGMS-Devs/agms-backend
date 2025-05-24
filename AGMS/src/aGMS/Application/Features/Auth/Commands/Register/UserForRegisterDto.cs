using Domain.Enums;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Auth.Commands.Register;

public class UserForRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PhoneNumber { get; set; }
    public UserType? UserType { get; set; } // Opsiyonel, email'e göre otomatik belirlenecek

    public UserForRegisterDto()
    {
        Email = string.Empty;
        Password = string.Empty;
        Name = string.Empty;
        Surname = string.Empty;
    }

    public UserForRegisterDto(string email, string password, string name, string surname, string? phoneNumber = null, UserType? userType = null)
    {
        Email = email;
        Password = password;
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        UserType = userType;
    }
} 