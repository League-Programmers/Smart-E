using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Migrations
{
    public partial class deletedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_typeAssessments_AssessmentTypeTypeID",
                table: "Assessments");

            migrationBuilder.DropTable(
                name: "typeAssessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_AssessmentTypeTypeID",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "AssessmentTypeTypeID",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Assessments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssessmentTypeTypeID",
                table: "Assessments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeID",
                table: "Assessments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "typeAssessments",
                columns: table => new
                {
                    TypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeAssessments", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentTypeTypeID",
                table: "Assessments",
                column: "AssessmentTypeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_typeAssessments_AssessmentTypeTypeID",
                table: "Assessments",
                column: "AssessmentTypeTypeID",
                principalTable: "typeAssessments",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
