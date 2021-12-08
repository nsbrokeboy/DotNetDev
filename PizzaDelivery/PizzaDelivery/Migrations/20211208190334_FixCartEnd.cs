using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaDelivery.Migrations
{
    public partial class FixCartEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCartItems_CartItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartItemId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "Orders",
                newName: "Username");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Orders",
                newName: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItemId",
                table: "Orders",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShoppingCartItems_CartItemId",
                table: "Orders",
                column: "CartItemId",
                principalTable: "ShoppingCartItems",
                principalColumn: "CartItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
