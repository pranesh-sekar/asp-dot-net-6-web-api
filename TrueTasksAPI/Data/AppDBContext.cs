using Microsoft.EntityFrameworkCore;
using TrueTasksAPI.Models;

namespace TrueTasksAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.Tasks)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
