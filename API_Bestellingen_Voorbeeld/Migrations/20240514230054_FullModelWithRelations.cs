using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Bestellingen_Voorbeeld.Migrations
{
    /// <inheritdoc />
    public partial class FullModelWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Gebruiker_GebruikerId",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Bestellinglijn_Bestelling_BestellingId",
                table: "Bestellinglijn");

            migrationBuilder.DropForeignKey(
                name: "FK_Bestellinglijn_Product_ProductId",
                table: "Bestellinglijn");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_Gebruiker_GebruikerId",
                table: "Bestelling",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellinglijn_Bestelling_BestellingId",
                table: "Bestellinglijn",
                column: "BestellingId",
                principalTable: "Bestelling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellinglijn_Product_ProductId",
                table: "Bestellinglijn",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_Gebruiker_GebruikerId",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Bestellinglijn_Bestelling_BestellingId",
                table: "Bestellinglijn");

            migrationBuilder.DropForeignKey(
                name: "FK_Bestellinglijn_Product_ProductId",
                table: "Bestellinglijn");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_Gebruiker_GebruikerId",
                table: "Bestelling",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellinglijn_Bestelling_BestellingId",
                table: "Bestellinglijn",
                column: "BestellingId",
                principalTable: "Bestelling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellinglijn_Product_ProductId",
                table: "Bestellinglijn",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
