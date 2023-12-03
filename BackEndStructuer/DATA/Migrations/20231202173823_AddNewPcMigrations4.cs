using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPcMigrations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserStorageBookMark",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "UserStorageBookMark",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserStorageBookMark",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserStorageBookMark");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "UserStorageBookMark");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserStorageBookMark");
        }
    }
}
