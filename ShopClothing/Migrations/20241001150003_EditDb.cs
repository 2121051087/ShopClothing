using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopClothing.Migrations
{
    /// <inheritdoc />
    public partial class EditDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColorSize");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "ColorSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ColorSizes_ProductID",
                table: "ColorSizes",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorSizes_Products_ProductID",
                table: "ColorSizes",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorSizes_Products_ProductID",
                table: "ColorSizes");

            migrationBuilder.DropIndex(
                name: "IX_ColorSizes_ProductID",
                table: "ColorSizes");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ColorSizes");

            migrationBuilder.CreateTable(
                name: "ProductColorSize",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColorSize", x => new { x.ProductID, x.SizeID });
                    table.ForeignKey(
                        name: "FK_ProductColorSize_ColorSizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "ColorSizes",
                        principalColumn: "ColorSizesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColorSize_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorSize_SizeID",
                table: "ProductColorSize",
                column: "SizeID");
        }
    }
}
