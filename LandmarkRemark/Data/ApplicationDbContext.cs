using LandmarkRemark.Models;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.Data
{

    /// <summary>
    /// The database representational model for the application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        /// <summary>
        /// Users of the application
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        /// <summary>
        /// Remarks entered by users.
        /// </summary>
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
