
using etiqa.Domain.Abstraction.Repositories;
using etiqa.Domain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;


namespace etiqa.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {   private readonly DataContext _appDbContext;
        public UserRepository(DataContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new Exception($"User with Id {userId} not found.");
            }

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> EditUserAsync(User user)
        {
            var existingUser = _appDbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (existingUser == null)
            {
                throw new Exception($"User with Username {user.UserName} not found.");
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Skillsets = user.Skillsets;
            existingUser.Hobby = user.Hobby;
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                existingUser.PasswordHash = new PasswordHasher().HashPassword(user.PasswordHash);
            }

            _appDbContext.Users.Update(existingUser);
            await _appDbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User> GetUserAsync(int id)
        {
           var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        
            return user;
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

      

    }
}
