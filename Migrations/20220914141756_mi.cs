using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_TypeOfAsses_TypeOfAssestypeAssesId",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_TypeOfAssestypeAssesId",
                table: "Assessments");

            migrationBuilder.DeleteData(
                table: "TypeOfAsses",
                keyColumn: "typeAssesId",
                keyValue: new Guid("6cfeea7f-dfb6-4d7d-aa6b-fc06c0420912"));

            migrationBuilder.DeleteData(
                table: "TypeOfAsses",
                keyColumn: "typeAssesId",
                keyValue: new Guid("f9213464-98b2-4bd9-aabf-37d0fed63b2c"));

            migrationBuilder.DropColumn(
                name: "TypeOfAssestypeAssesId",
                table: "Assessments");

            migrationBuilder.InsertData(
                table: "TypeOfAsses",
                columns: new[] { "typeAssesId", "typeAssesName" },
                values: new object[] { new Guid("80895c07-ee94-40b7-95f1-7bfcd401e891"), "Quiz" });

            migrationBuilder.InsertData(
                table: "TypeOfAsses",
                columns: new[] { "typeAssesId", "typeAssesName" },
                values: new object[] { new Guid("96e789e1-c8d1-45f2-a4f1-3e2246e9250c"), "Assignment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeOfAsses",
                keyColumn: "typeAssesId",
                keyValue: new Guid("80895c07-ee94-40b7-95f1-7bfcd401e891"));

            migrationBuilder.DeleteData(
                table: "TypeOfAsses",
                keyColumn: "typeAssesId",
                keyValue: new Guid("96e789e1-c8d1-45f2-a4f1-3e2246e9250c"));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfAssestypeAssesId",
                table: "Assessments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
