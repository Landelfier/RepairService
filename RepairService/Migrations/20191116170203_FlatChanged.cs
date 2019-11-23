using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class FlatChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Additionals_Flats_FlatID",
                table: "Additionals");

            migrationBuilder.DropIndex(
                name: "IX_Additionals_FlatID",
                table: "Additionals");

            migrationBuilder.DropColumn(
                name: "FlatID",
                table: "Additionals");

            migrationBuilder.CreateTable(
                name: "AdditionalsFlat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatID = table.Column<int>(nullable: false),
                    AdditionalOptionsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalsFlat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditionalsFlat_Additionals_AdditionalOptionsID",
                        column: x => x.AdditionalOptionsID,
                        principalTable: "Additionals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalsFlat_Flats_FlatID",
                        column: x => x.FlatID,
                        principalTable: "Flats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalsFlat_AdditionalOptionsID",
                table: "AdditionalsFlat",
                column: "AdditionalOptionsID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalsFlat_FlatID",
                table: "AdditionalsFlat",
                column: "FlatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalsFlat");

            migrationBuilder.AddColumn<int>(
                name: "FlatID",
                table: "Additionals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Additionals_FlatID",
                table: "Additionals",
                column: "FlatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Additionals_Flats_FlatID",
                table: "Additionals",
                column: "FlatID",
                principalTable: "Flats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
