using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SellerIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_seller_SellerID",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "SellerID",
                table: "client",
                newName: "seller_id");

            migrationBuilder.RenameIndex(
                name: "IX_client_SellerID",
                table: "client",
                newName: "IX_client_seller_id");

            migrationBuilder.AddForeignKey(
                name: "FK_client_seller_seller_id",
                table: "client",
                column: "seller_id",
                principalTable: "seller",
                principalColumn: "seller_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_seller_seller_id",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "seller_id",
                table: "client",
                newName: "SellerID");

            migrationBuilder.RenameIndex(
                name: "IX_client_seller_id",
                table: "client",
                newName: "IX_client_SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_client_seller_SellerID",
                table: "client",
                column: "SellerID",
                principalTable: "seller",
                principalColumn: "seller_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
