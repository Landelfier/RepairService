using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseSettings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variant = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    purpose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSettings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    Purpose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomSettings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WallsID = table.Column<int>(nullable: true),
                    DoorsID = table.Column<int>(nullable: true),
                    FloorID = table.Column<int>(nullable: true),
                    BaseboardID = table.Column<int>(nullable: true),
                    PowerSocketsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSettings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomSettings_Materials_BaseboardID",
                        column: x => x.BaseboardID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomSettings_Materials_DoorsID",
                        column: x => x.DoorsID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomSettings_Materials_FloorID",
                        column: x => x.FloorID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomSettings_Materials_PowerSocketsID",
                        column: x => x.PowerSocketsID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomSettings_Materials_WallsID",
                        column: x => x.WallsID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    Square = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    DoorNumber = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    BathroomID = table.Column<int>(nullable: true),
                    RoomsID = table.Column<int>(nullable: true),
                    KitchenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flats_BaseSettings_BathroomID",
                        column: x => x.BathroomID,
                        principalTable: "BaseSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flats_BaseSettings_KitchenID",
                        column: x => x.KitchenID,
                        principalTable: "BaseSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flats_RoomSettings_RoomsID",
                        column: x => x.RoomsID,
                        principalTable: "RoomSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flats_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Additionals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    FlatID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additionals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Additionals_Flats_FlatID",
                        column: x => x.FlatID,
                        principalTable: "Flats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Additionals_FlatID",
                table: "Additionals",
                column: "FlatID");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_BathroomID",
                table: "Flats",
                column: "BathroomID");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_KitchenID",
                table: "Flats",
                column: "KitchenID");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_RoomsID",
                table: "Flats",
                column: "RoomsID");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_UserID",
                table: "Flats",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_BaseboardID",
                table: "RoomSettings",
                column: "BaseboardID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_DoorsID",
                table: "RoomSettings",
                column: "DoorsID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_FloorID",
                table: "RoomSettings",
                column: "FloorID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_PowerSocketsID",
                table: "RoomSettings",
                column: "PowerSocketsID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSettings_WallsID",
                table: "RoomSettings",
                column: "WallsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Additionals");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "BaseSettings");

            migrationBuilder.DropTable(
                name: "RoomSettings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
