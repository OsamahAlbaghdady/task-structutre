using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLatLngForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Users",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Users",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Storage",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storage_UserId",
                table: "Storage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Users_UserId",
                table: "Storage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Users_UserId",
                table: "Storage");

            migrationBuilder.DropIndex(
                name: "IX_Storage_UserId",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Storage");
        }
    }
}
