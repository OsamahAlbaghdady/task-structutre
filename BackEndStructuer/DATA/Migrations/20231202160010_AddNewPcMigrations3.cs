using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPcMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservedStorages",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageId = table.Column<int>(type: "integer", nullable: false),
                    StartReserved = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndReserved = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedStorages", x => new { x.StorageId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_ReservedStorages_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedStorages_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservedStorages_AppUserId",
                table: "ReservedStorages",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservedStorages");
        }
    }
}
