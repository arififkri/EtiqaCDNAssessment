
using etiqa.Domain.Abstraction.Repositories;
using etiqa.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace etiqa.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {   private readonly DataContext _appDbContext;
        public UserRepository(DataContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
             _appDbContext.Users.Add(user);
             await _appDbContext.SaveChangesAsync();
             return user;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.Id == userId);
        
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> EditUserAsync(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();

            return user;
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
