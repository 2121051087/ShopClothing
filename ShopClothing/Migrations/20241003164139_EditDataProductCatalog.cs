using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopClothing.Migrations
{
    /// <inheritdoc />
    public partial class EditDataProductCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ColorSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ColorSizes");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
