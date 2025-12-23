using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantLigne",
                table: "LignesFacture");

            migrationBuilder.DropColumn(
                name: "MontantTotalHT",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "MontantTotalTTC",
                table: "Factures");

            migrationBuilder.AlterColumn<string>(
                name: "FactureRef",
                table: "Factures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MontantLigne",
                table: "LignesFacture",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "FactureRef",
                table: "Factures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<double>(
                name: "MontantTotalHT",
                table: "Factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MontantTotalTTC",
                table: "Factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
