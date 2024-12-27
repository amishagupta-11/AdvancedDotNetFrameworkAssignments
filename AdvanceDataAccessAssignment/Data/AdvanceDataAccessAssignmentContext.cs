using AdvanceDataAccessAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDataAccessAssignment.Data
{
    public class AdvanceDataAccessAssignmentContext : DbContext
    {
        public AdvanceDataAccessAssignmentContext(DbContextOptions<AdvanceDataAccessAssignmentContext> options)
                : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Electronics> Electronics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);         
                
            });
        }
    }
}
