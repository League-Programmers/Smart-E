using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220920 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "EventBooking");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "EventBooking",
                newName: "Status");

            migrationBuilder.AlterColumn<bool>(
                name: "BookingCompletedFlag",
                table: "BookingDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EventBookingBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Documents_EventBooking_EventBookingBookingId",
                        column: x => x.EventBookingBookingId,
                        principalTable: "EventBooking",
                        principalColumn: "BookingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EventBookingBookingId",
                table: "Documents",
                column: "EventBookingBookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "EventBooking",
                newName: "FileName");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "EventBooking",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<string>(
                name: "BookingCompletedFlag",
                table: "BookingDetails",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
