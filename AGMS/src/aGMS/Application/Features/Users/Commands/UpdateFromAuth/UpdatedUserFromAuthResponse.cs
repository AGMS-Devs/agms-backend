using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Users.Commands.UpdateFromAuth;

public class UpdatedUserFromAuthResponse : IResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public AccessToken AccessToken { get; set; }

    public UpdatedUserFromAuthResponse()
    {
        FullName = string.Empty;
        Email = string.Empty;
        AccessToken = null!;
    }

    public UpdatedUserFromAuthResponse(Guid id, string fullName, string email, AccessToken accessToken)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        AccessToken = accessToken;
    }
}
