using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220822 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "Transactions",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "Transactions",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 12);

            //migrationBuilder.AddColumn<int>(
            //    name: "UserId",
            //    table: "AspNetUsers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CVV",
                table: "Transactions",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Transactions",
                type: "int",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);
        }
    }
}
