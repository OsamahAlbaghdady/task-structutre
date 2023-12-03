using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPcMigrations8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStorageBookMark_Storage_StorageId",
                table: "UserStorageBookMark");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStorageBookMark_Users_AppUserId",
                table: "UserStorageBookMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStorageBookMark",
                table: "UserStorageBookMark");

            migrationBuilder.RenameTable(
                name: "UserStorageBookMark",
                newName: "Bookmark");

            migrationBuilder.RenameIndex(
                name: "IX_UserStorageBookMark_AppUserId",
                table: "Bookmark",
                newName: "IX_Bookmark_AppUserId");

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

            migrationBuilder.RenameTable(
                name: "Bookmark",
                newName: "UserStorageBookMark");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_AppUserId",
                table: "UserStorageBookMark",
                newName: "IX_UserStorageBookMark_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStorageBookMark",
                table: "UserStorageBookMark",
                columns: new[] { "StorageId", "AppUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserStorageBookMark_Storage_StorageId",
                table: "UserStorageBookMark",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStorageBookMark_Users_AppUserId",
                table: "UserStorageBookMark",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
