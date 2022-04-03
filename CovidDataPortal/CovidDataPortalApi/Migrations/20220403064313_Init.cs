using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidDataPortalApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deaths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleCollection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleTestedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysTestedBeforeDeath = table.Column<int>(type: "int", nullable: false),
                    DaysAdmitted = table.Column<int>(type: "int", nullable: false),
                    DaysAdmittedInICU = table.Column<int>(type: "int", nullable: false),
                    DaysInOxygenSupportOrVentillator = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deaths", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deaths");
        }
    }
}
