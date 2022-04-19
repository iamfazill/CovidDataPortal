using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidDataPortalApi.Migrations
{
    public partial class AddCasesClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "casesClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contacts = table.Column<int>(type: "int", nullable: true),
                    Comorbid = table.Column<int>(type: "int", nullable: true),
                    PrePostProcedural = table.Column<int>(type: "int", nullable: true),
                    Inpatient = table.Column<int>(type: "int", nullable: true),
                    Random = table.Column<int>(type: "int", nullable: true),
                    Traveller = table.Column<int>(type: "int", nullable: true),
                    Defence = table.Column<int>(type: "int", nullable: true),
                    Symptomatic = table.Column<int>(type: "int", nullable: true),
                    Gsp = table.Column<int>(type: "int", nullable: true),
                    Untraced = table.Column<int>(type: "int", nullable: true),
                    Reinfection = table.Column<int>(type: "int", nullable: true),
                    TotalDaysCases = table.Column<int>(type: "int", nullable: true),
                    ContactsTraced = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_casesClass", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "casesClass");
        }
    }
}
