using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class changeVariantToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Variant",
                table: "BaseSettings");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BaseSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BaseSettings");

            migrationBuilder.AddColumn<string>(
                name: "Variant",
                table: "BaseSettings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
