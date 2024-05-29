

using etiqa.Domain.Model;

namespace etiqa.Domain.Abstraction.Services
{
    public interface IAuthenticationService
    {

        Task<AuthenticatedUser> SignUp(User user);

        Task<AuthenticatedUser> SignIn(User user);
    }
}
