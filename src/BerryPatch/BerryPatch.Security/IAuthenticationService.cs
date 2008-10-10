using BerryPatch.Security;

namespace BerryPatch.Security
{
    public interface IAuthenticationService
    {
        AuthenticationStatus Authenticate(IUserRepository userToAuthenticate);
    }
}