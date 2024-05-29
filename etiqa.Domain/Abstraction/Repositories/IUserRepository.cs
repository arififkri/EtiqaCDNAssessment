using etiqa.Domain.Model;


namespace etiqa.Domain.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);

        Task<ICollection<User>> GetUsersAsync();

        Task<User> EditUserAsync(User user);

        Task<User> DeleteUserAsync(int userId);
    }
}
