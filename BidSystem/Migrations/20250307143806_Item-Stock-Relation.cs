using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidSystem.Migrations
{
    /// <inheritdoc />
    public partial class ItemStockRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItem_StockMovement_StockMovementId",
                table: "StockItem");

            migrationBuilder.DropIndex(
                name: "IX_StockItem_StockMovementId",
                table: "StockItem");

            migrationBuilder.DropColumn(
                name: "StockMovementId",
                table: "StockItem");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "StockMovement",
                newName: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovement_StockItemId",
                table: "StockMovement",
                column: "StockItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_StockItem_StockItemId",
                table: "StockMovement",
                column: "StockItemId",
                principalTable: "StockItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_StockItem_StockItemId",
                table: "StockMovement");

            migrationBuilder.DropIndex(
                name: "IX_StockMovement_StockItemId",
                table: "StockMovement");

            migrationBuilder.RenameColumn(
                name: "StockItemId",
                table: "StockMovement",
                newName: "ItemId");

            migrationBuilder.AddColumn<int>(
                name: "StockMovementId",
                table: "StockItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_StockMovementId",
                table: "StockItem",
                column: "StockMovementId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItem_StockMovement_StockMovementId",
                table: "StockItem",
                column: "StockMovementId",
                principalTable: "StockMovement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
