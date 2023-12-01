using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Storage",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Storage",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Features",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_StorageId",
                table: "Features",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Storage_StorageId",
                table: "Features",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Storage_StorageId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_StorageId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Features");
        }
    }
}
