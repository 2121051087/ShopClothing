using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopClothing.Migrations
{
    /// <inheritdoc />
    public partial class EditRelationshipFKProductAndCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_item_Products_ProductsProductID",
                table: "Cart_item");

            migrationBuilder.DropIndex(
                name: "IX_Cart_item_ProductsProductID",
                table: "Cart_item");

            migrationBuilder.DropColumn(
                name: "ProductsProductID",
                table: "Cart_item");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_item_ProductID",
                table: "Cart_item",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_item_Products_ProductID",
                table: "Cart_item",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_item_Products_ProductID",
                table: "Cart_item");

            migrationBuilder.DropIndex(
                name: "IX_Cart_item_ProductID",
                table: "Cart_item");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductID",
                table: "Cart_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_item_ProductsProductID",
                table: "Cart_item",
                column: "ProductsProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_item_Products_ProductsProductID",
                table: "Cart_item",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
