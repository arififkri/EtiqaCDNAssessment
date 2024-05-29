using etiqa.Domain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace etiqa.Dal
{
    public class DataContext : DbContext
    {

        private readonly IPasswordHasher _passwordHasher;

        public DataContext(DbContextOptions options) : base(options)
        {

        }

      
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminUser = new User
            {
                Id = 1,
                UserName = "Admin",
                Email = "admin@cdn.com",
                PhoneNumber = "1234567890",
                Skillsets = "",
                Hobby = "",
                PasswordHash = new PasswordHasher().HashPassword("Admin@123"),
                Role = "Admin"
            };

            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            };

            modelBuilder.Entity<User>().HasData(adminUser);
            modelBuilder.Entity<Role>().HasData(roles);
        }
    }
}
