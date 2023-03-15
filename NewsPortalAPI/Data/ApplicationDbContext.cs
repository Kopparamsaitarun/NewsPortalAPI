using Microsoft.EntityFrameworkCore;
using NewsPortalAPI.Models;

namespace NewsPortalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<User> User { get; set; }
    }
}