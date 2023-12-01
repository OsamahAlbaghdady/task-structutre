using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndStructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleNameToName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Roles",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "RoleName");
        }
    }
}
