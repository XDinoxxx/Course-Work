using Course.Models;
using Microsoft.EntityFrameworkCore;

namespace Course
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        
    }
}
