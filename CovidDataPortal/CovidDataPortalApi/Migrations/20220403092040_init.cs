using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidDataPortalApi.Migrations
{
    public partial class init : Migration
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
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleCollected = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleTestedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnderlyingCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalWhereAdmitted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaysTestedBeforeDeath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysAdmitted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysAdmittedInICU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysInOxygenSupportOrVentillator = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
