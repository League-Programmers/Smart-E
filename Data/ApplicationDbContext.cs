﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smart_E.Models;

namespace Smart_E.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Teachers> Teachers { get; set; }

        public DbSet<Invite> Invites { get; set; }
        public DbSet<LinkParentStudent> LinkParentStudent { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LinkParentStudent>().HasNoKey();
            

        }

       
    }
}