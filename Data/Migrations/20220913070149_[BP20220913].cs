using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220913 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Targets",
                table: "HOD",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "HOD",
                newName: "Qualifications");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "HOD",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "HOD",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "HOD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "HOD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "HOD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsFullDay",
            //    table: "Calendars",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "ThemeColor",
            //    table: "Calendars",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "HOD");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "HOD");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "HOD");

            //migrationBuilder.DropColumn(
            //    name: "IsFullDay",
            //    table: "Calendars");

            //migrationBuilder.DropColumn(
            //    name: "ThemeColor",
            //    table: "Calendars");

            migrationBuilder.RenameColumn(
                name: "Qualifications",
                table: "HOD",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "HOD",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "HOD",
                newName: "Targets");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "HOD",
                newName: "Active");
        }
    }
}
