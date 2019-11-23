using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class ColorChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialColors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialColors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialColors_Color_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialColors_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialColors_ColorID",
                table: "MaterialColors",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialColors_MaterialID",
                table: "MaterialColors",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialColors");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
