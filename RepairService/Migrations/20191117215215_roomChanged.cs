using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class roomChanged : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "WallsID",
                table: "RoomSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PowerSocketsID",
                table: "RoomSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FloorID",
                table: "RoomSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoorsID",
                table: "RoomSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseboardID",
                table: "RoomSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "WallsID",
                table: "RoomSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PowerSocketsID",
                table: "RoomSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FloorID",
                table: "RoomSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DoorsID",
                table: "RoomSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BaseboardID",
                table: "RoomSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
