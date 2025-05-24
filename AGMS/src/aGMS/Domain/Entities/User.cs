using NArchitecture.Core.Persistence.Repositories;
using Domain.Enums;
namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{

    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; } = true; // Default value
    public UserType UserType { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new HashSet<UserOperationClaim>();
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = new HashSet<OtpAuthenticator>();
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = new HashSet<EmailAuthenticator>();

    public virtual Student? StudentProfile { get; set; }
    public virtual Staff? StaffProfile { get; set; }
    public virtual Advisor? AdvisorProfile { get; set; }



    public User()
    {

    }

    public User(Guid id, string name, string surname, string phoneNumber, bool isActive, UserType userType)
    {
        Id = id;
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
        UserType = userType;
    }
    
}
