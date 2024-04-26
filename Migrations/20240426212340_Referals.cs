using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiCorpSite.Migrations
{
    /// <inheritdoc />
    public partial class Referals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppliedReferal",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferalCode",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedReferal",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ReferalCode",
                table: "Accounts");
        }
    }
}
