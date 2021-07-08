using Microsoft.EntityFrameworkCore;
using TrueTasksAPI.Models;

namespace TrueTasksAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
