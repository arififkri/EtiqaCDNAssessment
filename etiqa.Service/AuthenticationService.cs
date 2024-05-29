using etiqa.Dal;
using etiqa.Domain.Abstraction.Services;
using etiqa.Domain.Model;

using etiqa.Service.Utilities;
using Microsoft.AspNet.Identity;

using Microsoft.EntityFrameworkCore;


namespace etiqa.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(DataContext dataContext, IPasswordHasher passwordHasher)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticatedUser> SignUp(User user)
        {
            var checkUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            
            if (checkUser is not null)
            {
                return null;
            }

            user.PasswordHash = _passwordHasher.HashPassword(user.PasswordHash);
            var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Id == 2);

            var userrole = new UserRole()
            {
                User = user,
                Role = role

            };

            _dataContext.UserRoles.Add(userrole);

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return new AuthenticatedUser
            {

                UserName = user.UserName,
                Token = JwtGenerator.GenerateUserToken(user.UserName)

            };

        }


        public async Task<AuthenticatedUser> SignIn(User user)
        {
            var dbUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName);

            if (dbUser is null || _passwordHasher.VerifyHashedPassword(dbUser.PasswordHash, user.PasswordHash) == PasswordVerificationResult.Failed)
            {
               // throw new InvalidUsernamePasswordException("Invalid username and password");
            }

            return new AuthenticatedUser
            {
                UserName = user.UserName,
                Token = JwtGenerator.GenerateUserToken(user.UserName)
            };
        }
    }
}
