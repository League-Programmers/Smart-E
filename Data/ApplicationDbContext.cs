using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smart_E.Models;
using Smart_E.Models.Administrator;
using Smart_E.Models.Courses;

namespace Smart_E.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }

        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<AssessmentModel> Assessment { get; set; }
        public DbSet<TransactionsModel> Transactions { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<Parents> Parent { get; set; }  
        public DbSet<HODs> HOD { get; set; }
        public DbSet<Students> Student { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

        }

        public DbSet<Smart_E.Models.Qualification>? Qualification { get; set; }

       
    }
}