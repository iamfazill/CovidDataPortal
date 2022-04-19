using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidDataPortalApi.Migrations
{
    public partial class AncFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Anc",
                table: "casesClass",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anc",
                table: "casesClass");
        }
    }
}
