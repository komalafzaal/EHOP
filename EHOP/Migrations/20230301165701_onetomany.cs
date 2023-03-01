using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHOP.Migrations
{
    /// <inheritdoc />
    public partial class onetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "SellerId",
            table: "Products",
            nullable: false,
            defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
