using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smart_E.Models;
using Smart_E.Models.Courses;

namespace Smart_E.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }

        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<TypeOfAsses> TypeOfAsses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TypeOfAsses>().HasData(
               new TypeOfAsses { typeAssesId = Guid.NewGuid(), typeAssesName = "Quiz" },
               new TypeOfAsses { typeAssesId = Guid.NewGuid(), typeAssesName = "Assignment" }
               
           );
        }

       
    }
}