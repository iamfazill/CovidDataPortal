using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidDataPortalApi.Migrations
{
    public partial class columnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DaysTestedBeforeDeath",
                table: "Deaths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DaysInOxygenSupportOrVentillator",
                table: "Deaths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DaysAdmittedInICU",
                table: "Deaths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DaysAdmitted",
                table: "Deaths",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "HospitalWhereAdmitted",
                table: "Deaths",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnderlyingCondition",
                table: "Deaths",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalWhereAdmitted",
                table: "Deaths");

            migrationBuilder.DropColumn(
                name: "UnderlyingCondition",
                table: "Deaths");

            migrationBuilder.AlterColumn<int>(
                name: "DaysTestedBeforeDeath",
                table: "Deaths",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DaysInOxygenSupportOrVentillator",
                table: "Deaths",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DaysAdmittedInICU",
                table: "Deaths",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DaysAdmitted",
                table: "Deaths",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
