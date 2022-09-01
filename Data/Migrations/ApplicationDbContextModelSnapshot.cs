﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart_E.Data;

#nullable disable

namespace Smart_E.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            //#pragma warning disable 612, 618
            //            modelBuilder
            //                .HasAnnotation("ProductVersion", "6.0.3")
            //                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            //            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            //                {
            //                    b.Property<string>("Id")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("ConcurrencyStamp")
            //                        .IsConcurrencyToken()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Name")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<string>("NormalizedName")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.HasKey("Id");

            //                    b.HasIndex("NormalizedName")
            //                        .IsUnique()
            //                        .HasDatabaseName("RoleNameIndex")
            //                        .HasFilter("[NormalizedName] IS NOT NULL");

            //                    b.ToTable("AspNetRoles", (string)null);
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            //                {
            //                    b.Property<int>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("int");

            //                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            //                    b.Property<string>("ClaimType")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("ClaimValue")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("RoleId")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(450)");

            //                    b.HasKey("Id");

            //                    b.HasIndex("RoleId");

            //                    b.ToTable("AspNetRoleClaims", (string)null);
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            //                {
            //                    b.Property<int>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("int");

            //                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            //                    b.Property<string>("ClaimType")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("ClaimValue")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("UserId")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(450)");

            //                    b.HasKey("Id");

            //                    b.HasIndex("UserId");

            //                    b.ToTable("AspNetUserClaims", (string)null);
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            //                {
            //                    b.Property<string>("LoginProvider")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("ProviderKey")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("ProviderDisplayName")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("UserId")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(450)");

            //                    b.HasKey("LoginProvider", "ProviderKey");

            //                    b.HasIndex("UserId");

            //                    b.ToTable("AspNetUserLogins", (string)null);
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            //                {
            //                    b.Property<string>("UserId")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("RoleId")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.HasKey("UserId", "RoleId");

            //                    b.HasIndex("RoleId");

            //                    b.ToTable("AspNetUserRoles", (string)null);
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            //                {
            //                    b.Property<string>("UserId")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("LoginProvider")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("Name")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<string>("Value")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.HasKey("UserId", "LoginProvider", "Name");

            //                    b.ToTable("AspNetUserTokens", (string)null);
            //                });

            //            modelBuilder.Entity("Smart_E.Data.Calendar", b =>
            //                {
            //                    b.Property<Guid>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("uniqueidentifier");

            //                    b.Property<string>("Description")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("End")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("IsFullDayEvent")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("Start")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Subject")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Theme")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.HasKey("Id");

            //                    b.ToTable("Calendars");
            //                });

            //            modelBuilder.Entity("Smart_E.Data.ChatRoom", b =>
            //                {
            //                    b.Property<Guid>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("uniqueidentifier");

            //                    b.Property<string>("Comment")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<DateTime>("DateTime")
            //                        .HasColumnType("datetime2");

            //                    b.Property<string>("UserId")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.HasKey("Id");

            //                    b.ToTable("ChatRoom");
            //                });

            //            modelBuilder.Entity("Smart_E.Data.Course", b =>
            //                {
            //                    b.Property<Guid>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("uniqueidentifier");

            //                    b.Property<string>("CourseName")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Grade")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.HasKey("Id");

            //                    b.ToTable("Course");
            //                });

            //            modelBuilder.Entity("Smart_E.Models.ApplicationUser", b =>
            //                {
            //                    b.Property<string>("Id")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<int>("AccessFailedCount")
            //                        .HasColumnType("int");

            //                    b.Property<string>("ConcurrencyStamp")
            //                        .IsConcurrencyToken()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Email")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<bool>("EmailConfirmed")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("FirstName")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Name")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("LockoutEnabled")
            //                        .HasColumnType("bit");

            //                    b.Property<DateTimeOffset?>("LockoutEnd")
            //                        .HasColumnType("datetimeoffset");

            //                    b.Property<string>("NormalizedEmail")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<string>("NormalizedUserName")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<string>("PasswordHash")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("PhoneNumber")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("PhoneNumberConfirmed")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("SecurityStamp")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("TwoFactorEnabled")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("UserName")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.HasKey("Id");

            //                    b.ToTable("Teachers");
            //                });

            //            modelBuilder.Entity("Smart_E.Models.Administrator.HODs", b =>
            //                {
            //                    b.Property<int>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("int");

            //                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            //                    b.Property<string>("Active")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Department")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Email")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Name")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<int>("Targets")
            //                        .HasColumnType("int");

            //                    b.HasKey("Id");

            //                    b.ToTable("HOD");
            //                });

            //            modelBuilder.Entity("Smart_E.Models.Administrator.Parents", b =>
            //                {
            //                    b.Property<int>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("int");

            //                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            //                    b.Property<string>("Active")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Email")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Name")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<int>("Progress")
            //                        .HasColumnType("int");

            //                    b.Property<int>("StudentName")
            //                        .HasColumnType("int");

            //                    b.Property<string>("Subjects")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("TeacherEmail")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.HasKey("Id");

            //                    b.ToTable("Parent");
            //                });

            //            modelBuilder.Entity("Smart_E.Models.Administrator.TeachersReport", b =>
            //                {
            //                    b.Property<int>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("int");

            //                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            //                    b.Property<string>("Active")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Email")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<int>("Grade")
            //                        .HasColumnType("int");

            //                    b.Property<string>("Name")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Qualification")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Subjects")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<int>("TargetsAchieved")
            //                        .HasColumnType("int");

            //                    b.HasKey("Id");

            //                    b.ToTable("TeachersReport");
            //                });

            //            modelBuilder.Entity("Smart_E.Models.ApplicationUser", b =>
            //                {
            //                    b.Property<string>("Id")
            //                        .HasColumnType("nvarchar(450)");

            //                    b.Property<int>("AccessFailedCount")
            //                        .HasColumnType("int");

            //                    b.Property<string>("Active")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("ConcurrencyStamp")
            //                        .IsConcurrencyToken()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Email")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<bool>("EmailConfirmed")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("FirstName")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("LastName")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("LockoutEnabled")
            //                        .HasColumnType("bit");

            //                    b.Property<DateTimeOffset?>("LockoutEnd")
            //                        .HasColumnType("datetimeoffset");

            //                    b.Property<string>("NormalizedEmail")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<string>("NormalizedUserName")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.Property<string>("PasswordHash")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("PhoneNumber")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("PhoneNumberConfirmed")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("Role")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("SecurityStamp")
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<bool>("TwoFactorEnabled")
            //                        .HasColumnType("bit");

            //                    b.Property<string>("UserName")
            //                        .HasMaxLength(256)
            //                        .HasColumnType("nvarchar(256)");

            //                    b.HasKey("Id");

            //                    b.HasIndex("NormalizedEmail")
            //                        .HasDatabaseName("EmailIndex");

            //                    b.HasIndex("NormalizedUserName")
            //                        .IsUnique()
            //                        .HasDatabaseName("UserNameIndex")
            //                        .HasFilter("[NormalizedUserName] IS NOT NULL");

            //                    b.ToTable("AspNetUsers", (string)null);
            //                });

            //            modelBuilder.Entity("Smart_E.Models.Students", b =>
            //                {
            //                    b.Property<int>("Id")
            //                        .ValueGeneratedOnAdd()
            //                        .HasColumnType("int");

            //                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            //                    b.Property<string>("Active")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<string>("Email")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<int>("Grade")
            //                        .HasColumnType("int");

            //                    b.Property<string>("Name")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.Property<int>("Progress")
            //                        .HasColumnType("int");

            //                    b.Property<string>("Subjects")
            //                        .IsRequired()
            //                        .HasColumnType("nvarchar(max)");

            //                    b.HasKey("Id");

            //                    b.ToTable("Student");
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            //                {
            //                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
            //                        .WithMany()
            //                        .HasForeignKey("RoleId")
            //                        .OnDelete(DeleteBehavior.Cascade)
            //                        .IsRequired();
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            //                {
            //                    b.HasOne("Smart_E.Models.ApplicationUser", null)
            //                        .WithMany()
            //                        .HasForeignKey("UserId")
            //                        .OnDelete(DeleteBehavior.Cascade)
            //                        .IsRequired();
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            //                {
            //                    b.HasOne("Smart_E.Models.ApplicationUser", null)
            //                        .WithMany()
            //                        .HasForeignKey("UserId")
            //                        .OnDelete(DeleteBehavior.Cascade)
            //                        .IsRequired();
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            //                {
            //                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
            //                        .WithMany()
            //                        .HasForeignKey("RoleId")
            //                        .OnDelete(DeleteBehavior.Cascade)
            //                        .IsRequired();

            //                    b.HasOne("Smart_E.Models.ApplicationUser", null)
            //                        .WithMany()
            //                        .HasForeignKey("UserId")
            //                        .OnDelete(DeleteBehavior.Cascade)
            //                        .IsRequired();
            //                });

            //            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            //                {
            //                    b.HasOne("Smart_E.Models.ApplicationUser", null)
            //                        .WithMany()
            //                        .HasForeignKey("UserId")
            //                        .OnDelete(DeleteBehavior.Cascade)
            //                        .IsRequired();
            //                });
            //#pragma warning restore 612, 618
        }
    }
}
