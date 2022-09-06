using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_E.Data.Migrations
{
    public partial class CL20220510a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Subject",
            //    columns: table => new
            //    {
            //        SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Subject", x => x.SubjectId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Subject");
        }
    }
}
