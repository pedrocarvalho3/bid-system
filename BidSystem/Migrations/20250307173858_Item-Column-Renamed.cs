using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidSystem.Migrations
{
    /// <inheritdoc />
    public partial class ItemColumnRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Item_StockItemId",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "StockItemId",
                table: "StockMovement",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_StockItemId",
                table: "StockMovement",
                newName: "IX_StockMovement_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Item_ItemId",
                table: "StockMovement",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Item_ItemId",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "StockMovement",
                newName: "StockItemId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovement_ItemId",
                table: "StockMovement",
                newName: "IX_StockMovement_StockItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Item_StockItemId",
                table: "StockMovement",
                column: "StockItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
