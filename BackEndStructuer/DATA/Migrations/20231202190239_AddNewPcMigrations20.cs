using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPcMigrations20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Storage_StorageId",
                table: "Bookmark");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Users_AppUserId",
                table: "Bookmark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Bookmark",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Bookmark",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Bookmark",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_StorageId",
                table: "Bookmark",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Storage_StorageId",
                table: "Bookmark",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Users_AppUserId",
                table: "Bookmark",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Storage_StorageId",
                table: "Bookmark");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Users_AppUserId",
                table: "Bookmark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.DropIndex(
                name: "IX_Bookmark_StorageId",
                table: "Bookmark");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Bookmark",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Bookmark",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Bookmark",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark",
                columns: new[] { "StorageId", "AppUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Storage_StorageId",
                table: "Bookmark",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Users_AppUserId",
                table: "Bookmark",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
