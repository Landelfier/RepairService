using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class roomNext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_BaseboardID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_DoorsID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_FloorID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_PowerSocketsID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_WallsID",
                table: "RoomSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_BaseboardID",
                table: "RoomSettings",
                column: "BaseboardID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_DoorsID",
                table: "RoomSettings",
                column: "DoorsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_FloorID",
                table: "RoomSettings",
                column: "FloorID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_PowerSocketsID",
                table: "RoomSettings",
                column: "PowerSocketsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_WallsID",
                table: "RoomSettings",
                column: "WallsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_BaseboardID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_DoorsID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_FloorID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_PowerSocketsID",
                table: "RoomSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSettings_Materials_WallsID",
                table: "RoomSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_BaseboardID",
                table: "RoomSettings",
                column: "BaseboardID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_DoorsID",
                table: "RoomSettings",
                column: "DoorsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_FloorID",
                table: "RoomSettings",
                column: "FloorID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_PowerSocketsID",
                table: "RoomSettings",
                column: "PowerSocketsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSettings_Materials_WallsID",
                table: "RoomSettings",
                column: "WallsID",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
