using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiCorpSite.Migrations
{
    /// <inheritdoc />
    public partial class Referal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CreditedFunds",
                table: "Accounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditedFunds",
                table: "Accounts");
        }
    }
}
