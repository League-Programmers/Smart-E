using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220917a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPlanner");

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingApproval = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BookingApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingCompletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "EventBooking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBooking", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "EventBooking");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.CreateTable(
                name: "EventPlanner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFullDay = table.Column<bool>(type: "bit", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlanner", x => x.Id);
                });
        }
    }
}
