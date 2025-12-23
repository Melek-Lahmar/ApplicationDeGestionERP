using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class AppQTERP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactureRef",
                table: "Factures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FactureRef",
                table: "Factures");
        }
    }
}
