using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Smart_E.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<ApplicationUser>()
            .ToTable(nameof(ApplicationUsers), "dbo")
            .HasKey(x => new { Guid = x.Id
            });
        }

       
    }
}