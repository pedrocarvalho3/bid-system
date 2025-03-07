using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_StockItem_StockItemId",
                table: "StockMovement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockItem",
                table: "StockItem");

            migrationBuilder.RenameTable(
                name: "StockItem",
                newName: "Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_Item_StockItemId",
                table: "StockMovement",
                column: "StockItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovement_Item_StockItemId",
                table: "StockMovement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "StockItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockItem",
                table: "StockItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovement_StockItem_StockItemId",
                table: "StockMovement",
                column: "StockItemId",
                principalTable: "StockItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
