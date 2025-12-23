using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class AppLigne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MontantLigne",
                table: "LignesFacture",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantLigne",
                table: "LignesFacture");
        }
    }
}
