using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopClothing.Migrations
{
    /// <inheritdoc />
    public partial class EditDelebehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_item_Carts_CartID",
                table: "Cart_item");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_item_Carts_CartID",
                table: "Cart_item",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_item_Carts_CartID",
                table: "Cart_item");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_item_Carts_CartID",
                table: "Cart_item",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
