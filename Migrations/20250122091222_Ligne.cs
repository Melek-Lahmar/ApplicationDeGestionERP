using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class Ligne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PrixUnitaire",
                table: "LignesFacture",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MatriculeFiscale",
                table: "Fournisseurs",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixUnitaire",
                table: "LignesFacture");

            migrationBuilder.DropColumn(
                name: "MatriculeFiscale",
                table: "Fournisseurs");
        }
    }
}
