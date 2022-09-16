using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220904a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "AspNetUsers",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "Role",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Status",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<int>(
            //    name: "UserId",
            //    table: "AspNetUsers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "Assessment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AssessmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Assessment", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HOD",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            //migrationBuilder.CreateTable(
            //    name: "Teachers",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Teachers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Transactions",
            //    columns: table => new
            //    {
            //        TransactionId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AccountNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
            //        BeneficiaryName = table.Column<string>(type: "nvarchar(100)", nullable: false),
            //        BankName = table.Column<string>(type: "nvarchar(100)", nullable: false),
            //        CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
            //        Amount = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Transactions", x => x.TransactionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Uploads",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SubmissionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Uploads", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "HOD");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Uploads");

            //migrationBuilder.DropColumn(
            //    name: "IsDeleted",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Role",
            //    table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
