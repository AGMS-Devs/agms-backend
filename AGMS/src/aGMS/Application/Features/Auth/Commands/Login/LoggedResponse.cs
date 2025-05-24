using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;
using Domain.Enums;

namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{
    public AccessToken? AccessToken { get; set; }
    public Domain.Entities.RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    public Domain.Enums.UserType UserType { get; set; }
    public Domain.Enums.StaffRole? StaffRole { get; set; }

    public LoggedHttpResponse ToHttpResponse()
    {
        return new LoggedHttpResponse 
        { 
            AccessToken = AccessToken, 
            RequiredAuthenticatorType = RequiredAuthenticatorType, 
            UserType = UserType,
            UserTypeValue = (int)UserType,
            StaffRole = StaffRole,
            StaffRoleValue = StaffRole.HasValue ? (int)StaffRole.Value : (int?)null
        };
    }

    public class LoggedHttpResponse
    {
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        public Domain.Enums.UserType UserType { get; set; }
        public int UserTypeValue { get; set; }
        public Domain.Enums.StaffRole? StaffRole { get; set; }
        public int? StaffRoleValue { get; set; }
    }
}
