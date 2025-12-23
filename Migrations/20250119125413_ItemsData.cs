using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class ItemsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdresseClient = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelephoneClient = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    IDFournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFournisseur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TotalMontantAchete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantPaye = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.IDFournisseur);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceArticle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomArticle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescriptionArticle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    QteStockArticle = table.Column<int>(type: "int", nullable: false),
                    PrixDeVente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TVA = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categories",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    FactureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    MontantTotalHT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantTotalTTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.FactureID);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LigneFactures",
                columns: table => new
                {
                    LigneFactureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    G_FactureFactureID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFactures", x => x.LigneFactureID);
                    table.ForeignKey(
                        name: "FK_LigneFactures_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneFactures_Factures_G_FactureFactureID",
                        column: x => x.G_FactureFactureID,
                        principalTable: "Factures",
                        principalColumn: "FactureID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategorieID",
                table: "Articles",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientID",
                table: "Factures",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFactures_ArticleID",
                table: "LigneFactures",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFactures_G_FactureFactureID",
                table: "LigneFactures",
                column: "G_FactureFactureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "LigneFactures");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
