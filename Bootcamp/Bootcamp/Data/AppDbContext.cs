using Bootcamp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bootcamper> Bootcampers { get; set; }
        public DbSet<Mentor> Mentors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mentor>()
                .HasMany(m => m.Bootcampers)
                .WithOne(b => b.Mentor)
                .HasForeignKey(b => b.MentorId);
        }
    }

}
