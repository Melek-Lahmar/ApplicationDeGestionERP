using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationDeGestionERP.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15ab5a65-580f-496e-b67c-acf20e81f669", "1cbeb38d-71a9-4a49-9744-4d150dd6490c", "User", "user" },
                    { "dd898b2d-d2b2-4d02-b16f-6886400c1381", "322cdd25-ae2b-4b85-8aa6-da8fd2804c97", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15ab5a65-580f-496e-b67c-acf20e81f669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd898b2d-d2b2-4d02-b16f-6886400c1381");
        }
    }
}
