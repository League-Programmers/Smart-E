﻿using Microsoft.AspNetCore.Identity;
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
        public DbSet<Assignments> Assignments { get; set; }

        public DbSet<MyCourses> MyCourses { get; set; }

        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assign> Assign { get; set; }
        public DbSet<TransactionsModel> Transactions { get; set; }
        public DbSet<Invite> Invites { get; set; } 
        public DbSet<Qualifications> Qualifications { get; set; } 
        public DbSet<EnrollmentReport> EnrollmentReports { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

        }

       
    }
}