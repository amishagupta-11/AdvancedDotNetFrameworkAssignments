using AdvanceDataAccessAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDataAccessAssignment.Data
{
    /// <summary>
    /// Represents the context class for accessing and managing data related to Users and Electronics.
    /// This class is responsible for configuring the database and mapping entities to tables.
    /// </summary>
    public class AdvanceDataAccessAssignmentContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="options">The options to be passed to the DbContext for configuration.</param>
        public AdvanceDataAccessAssignmentContext(DbContextOptions<AdvanceDataAccessAssignmentContext> options)
                : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet for the Users entity.
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for the Electronics entity.
        /// </summary>
        public DbSet<Electronics> Electronics { get; set; }

        /// <summary>
        /// Configures the model for the Users and Electronics entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the Users entity
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);
            });

        }
    }
}
