
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220921 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_EventBooking_EventBookingBookingId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_EventBookingBookingId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "EventBooking");

            migrationBuilder.DropColumn(
                name: "EventBookingBookingId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "EventBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "EventBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "EventBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventBooking");

            migrationBuilder.DropColumn(
                name: "End",
                table: "EventBooking");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "EventBooking");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "EventBooking");

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "EventBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventBookingBookingId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EventBookingBookingId",
                table: "Documents",
                column: "EventBookingBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_EventBooking_EventBookingBookingId",
                table: "Documents",
                column: "EventBookingBookingId",
                principalTable: "EventBooking",
                principalColumn: "BookingId");
        }
    }
}
