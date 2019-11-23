using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class ColorChanged_N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "BaseSettings");

            migrationBuilder.CreateTable(
                name: "SettingsColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseSettingsID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsColor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SettingsColor_BaseSettings_BaseSettingsID",
                        column: x => x.BaseSettingsID,
                        principalTable: "BaseSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingsColor_Color_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingsColor_BaseSettingsID",
                table: "SettingsColor",
                column: "BaseSettingsID");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsColor_ColorID",
                table: "SettingsColor",
                column: "ColorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingsColor");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "BaseSettings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
