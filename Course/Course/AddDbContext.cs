using Course.Models;
using Microsoft.EntityFrameworkCore;

namespace Course
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Gradebooks> Gradebooks { get; set; }
        public DbSet<Averages> Averages { get; set; }

        public int GetUserId(Users user)
        {
            var foundUser = Users.FirstOrDefault(u => u.login == user.login && u.password == user.password);

            return foundUser?.id ?? 0; 
        }
    }
}