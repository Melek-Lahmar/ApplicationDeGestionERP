using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigneFactures_Articles_ArticleID",
                table: "LigneFactures");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneFactures_Factures_G_FactureFactureID",
                table: "LigneFactures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LigneFactures",
                table: "LigneFactures");

            migrationBuilder.DropIndex(
                name: "IX_LigneFactures_G_FactureFactureID",
                table: "LigneFactures");

            migrationBuilder.DropColumn(
                name: "G_FactureFactureID",
                table: "LigneFactures");

            migrationBuilder.DropColumn(
                name: "PrixUnitaire",
                table: "LigneFactures");

            migrationBuilder.RenameTable(
                name: "LigneFactures",
                newName: "LignesFacture");

            migrationBuilder.RenameIndex(
                name: "IX_LigneFactures_ArticleID",
                table: "LignesFacture",
                newName: "IX_LignesFacture_ArticleID");

            migrationBuilder.AlterColumn<double>(
                name: "TotalMontantAchete",
                table: "Fournisseurs",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "MontantPaye",
                table: "Fournisseurs",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "MontantTotalTTC",
                table: "Factures",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "MontantTotalHT",
                table: "Factures",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "MatriculeFiscaleOuCin",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrénomClient",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeClient",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionCategorie",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "PrixDeVente",
                table: "Articles",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Articles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PrixAchat",
                table: "Articles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FactureID",
                table: "LignesFacture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LignesFacture",
                table: "LignesFacture",
                column: "LigneFactureID");

            migrationBuilder.CreateIndex(
                name: "IX_LignesFacture_FactureID",
                table: "LignesFacture",
                column: "FactureID");

            migrationBuilder.AddForeignKey(
                name: "FK_LignesFacture_Articles_ArticleID",
                table: "LignesFacture",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ArticleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesFacture_Factures_FactureID",
                table: "LignesFacture",
                column: "FactureID",
                principalTable: "Factures",
                principalColumn: "FactureID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignesFacture_Articles_ArticleID",
                table: "LignesFacture");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesFacture_Factures_FactureID",
                table: "LignesFacture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LignesFacture",
                table: "LignesFacture");

            migrationBuilder.DropIndex(
                name: "IX_LignesFacture_FactureID",
                table: "LignesFacture");

            migrationBuilder.DropColumn(
                name: "MatriculeFiscaleOuCin",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PrénomClient",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TypeClient",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DescriptionCategorie",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "PrixAchat",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FactureID",
                table: "LignesFacture");

            migrationBuilder.RenameTable(
                name: "LignesFacture",
                newName: "LigneFactures");

            migrationBuilder.RenameIndex(
                name: "IX_LignesFacture_ArticleID",
                table: "LigneFactures",
                newName: "IX_LigneFactures_ArticleID");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalMontantAchete",
                table: "Fournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantPaye",
                table: "Fournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantTotalTTC",
                table: "Factures",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantTotalHT",
                table: "Factures",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixDeVente",
                table: "Articles",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "G_FactureFactureID",
                table: "LigneFactures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixUnitaire",
                table: "LigneFactures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LigneFactures",
                table: "LigneFactures",
                column: "LigneFactureID");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFactures_G_FactureFactureID",
                table: "LigneFactures",
                column: "G_FactureFactureID");

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFactures_Articles_ArticleID",
                table: "LigneFactures",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ArticleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFactures_Factures_G_FactureFactureID",
                table: "LigneFactures",
                column: "G_FactureFactureID",
                principalTable: "Factures",
                principalColumn: "FactureID");
        }
    }
}
