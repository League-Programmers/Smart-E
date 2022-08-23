using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class BP20220817 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TeachersReport",
                newName: "Status");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TeachersReport",
                newName: "Active");
        }
    }
}
