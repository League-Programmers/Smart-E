using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smart_E.Models;
using Smart_E.Models.Administrator;

namespace Smart_E.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Teachers> Teachers { get; set; }

        public DbSet<Parents> Parent { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<HODs> HOD { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<TeachersReport> TeachersReport { get; set; }
        public DbSet<TransactionsModel> Transactions { get; set; }
        public DbSet<AssessmentModel> Assessment { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Upload>(entity =>
            {
                entity.Property(x => x.Date).HasColumnType("datetime");
            });

        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries())
        //    {
        //        var entity = entry.Entity;
        //        if(entry.State == EntityState.Deleted)
        //        {
        //            entry.State = EntityState.Modified;
                    
        //            entity.GetType().GetProperty("Status").SetValue(entity,"Inactive");
        //        }
        //    }
        //    return base.SaveChanges();
        //}


    }
}