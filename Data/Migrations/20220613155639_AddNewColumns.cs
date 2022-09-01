using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class AddNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ContentType",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Gender",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "ProfileImage",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "ProfilePictureFileName",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Role",
            //    table: "AspNetUsers");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LastName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(100)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "FirstName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(100)");

            //migrationBuilder.CreateTable(
            //    name: "HOD",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Grade = table.Column<int>(type: "int", nullable: false),
            //        Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Targets = table.Column<int>(type: "int", nullable: false),
            //        Active = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HOD", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Parent",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StudentName = table.Column<int>(type: "int", nullable: false),
            //        Subjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TeacherEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Progress = table.Column<int>(type: "int", nullable: false),
            //        Active = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Parent", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Student",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Grade = table.Column<int>(type: "int", nullable: false),
            //        Subjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Progress = table.Column<int>(type: "int", nullable: false),
            //        Active = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Student", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "HOD");

            //migrationBuilder.DropTable(
            //    name: "Parent");

            //migrationBuilder.DropTable(
            //    name: "Student");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LastName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(100)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "FirstName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(100)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<string>(
            //    name: "ContentType",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Gender",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<byte[]>(
            //    name: "ProfileImage",
            //    table: "AspNetUsers",
            //    type: "varbinary(max)",
            //    nullable: false,
            //    defaultValue: new byte[0]);

            //migrationBuilder.AddColumn<string>(
            //    name: "ProfilePictureFileName",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Role",
            //    table: "AspNetUsers",
            //    type: "nvarchar(100)",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
