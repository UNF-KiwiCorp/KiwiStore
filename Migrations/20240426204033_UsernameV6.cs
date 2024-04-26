using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiCorpSite.Migrations
{
    /// <inheritdoc />
    public partial class UsernameV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Accounts",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Accounts",
                newName: "UserName");
        }
    }
}
