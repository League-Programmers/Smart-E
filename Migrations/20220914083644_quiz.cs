using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Migrations
{
    public partial class quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfAssestypeAssesId",
                table: "Assessments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "typeAssesId",
                table: "Assessments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TypeOfAsses",
                columns: table => new
                {
                    typeAssesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeAssesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfAsses", x => x.typeAssesId);
                });

            migrationBuilder.InsertData(
                table: "TypeOfAsses",
                columns: new[] { "typeAssesId", "typeAssesName" },
                values: new object[] { new Guid("6cfeea7f-dfb6-4d7d-aa6b-fc06c0420912"), "Quiz" });

            migrationBuilder.InsertData(
                table: "TypeOfAsses",
                columns: new[] { "typeAssesId", "typeAssesName" },
                values: new object[] { new Guid("f9213464-98b2-4bd9-aabf-37d0fed63b2c"), "Assignment" });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_TypeOfAssestypeAssesId",
                table: "Assessments",
                column: "TypeOfAssestypeAssesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_TypeOfAsses_TypeOfAssestypeAssesId",
                table: "Assessments",
                column: "TypeOfAssestypeAssesId",
                principalTable: "TypeOfAsses",
                principalColumn: "typeAssesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_TypeOfAsses_TypeOfAssestypeAssesId",
                table: "Assessments");

            migrationBuilder.DropTable(
                name: "TypeOfAsses");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_TypeOfAssestypeAssesId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "TypeOfAssestypeAssesId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "typeAssesId",
                table: "Assessments");
        }
    }
}
