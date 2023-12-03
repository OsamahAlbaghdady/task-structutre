using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReserve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedStorages_Storage_StorageId",
                table: "ReservedStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedStorages_Users_AppUserId",
                table: "ReservedStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedStorages",
                table: "ReservedStorages");

            migrationBuilder.DropIndex(
                name: "IX_ReservedStorages_AppUserId",
                table: "ReservedStorages");

            migrationBuilder.RenameColumn(
                name: "StartReserved",
                table: "ReservedStorages",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndReserved",
                table: "ReservedStorages",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ReservedStorages",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "ReservedStorages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ReservedStorages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ReservedStorages",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ReservedStorages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "ReservedStorages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ReservedStorages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ReservedStorages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedStorages",
                table: "ReservedStorages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedStorages_StorageId",
                table: "ReservedStorages",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedStorages_UserId",
                table: "ReservedStorages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedStorages_Storage_StorageId",
                table: "ReservedStorages",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedStorages_Users_UserId",
                table: "ReservedStorages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedStorages_Storage_StorageId",
                table: "ReservedStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedStorages_Users_UserId",
                table: "ReservedStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedStorages",
                table: "ReservedStorages");

            migrationBuilder.DropIndex(
                name: "IX_ReservedStorages_StorageId",
                table: "ReservedStorages");

            migrationBuilder.DropIndex(
                name: "IX_ReservedStorages_UserId",
                table: "ReservedStorages");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "ReservedStorages");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ReservedStorages");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ReservedStorages");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "ReservedStorages");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ReservedStorages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReservedStorages");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ReservedStorages",
                newName: "StartReserved");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "ReservedStorages",
                newName: "EndReserved");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReservedStorages",
                newName: "AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "ReservedStorages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedStorages",
                table: "ReservedStorages",
                columns: new[] { "StorageId", "AppUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReservedStorages_AppUserId",
                table: "ReservedStorages",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedStorages_Storage_StorageId",
                table: "ReservedStorages",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedStorages_Users_AppUserId",
                table: "ReservedStorages",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
