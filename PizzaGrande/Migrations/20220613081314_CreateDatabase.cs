using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaGrande.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "18118057");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCart",
                newSchema: "18118057");

            migrationBuilder.RenameTable(
                name: "Pizza",
                newName: "Pizza",
                newSchema: "18118057");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetail",
                newSchema: "18118057");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Order",
                newSchema: "18118057");

            migrationBuilder.RenameTable(
                name: "Drink",
                newName: "Drink",
                newSchema: "18118057");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category",
                newSchema: "18118057");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                schema: "18118057",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "Pizza",
                schema: "18118057",
                newName: "Pizza");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                schema: "18118057",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "18118057",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Drink",
                schema: "18118057",
                newName: "Drink");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "18118057",
                newName: "Category");
        }
    }
}
