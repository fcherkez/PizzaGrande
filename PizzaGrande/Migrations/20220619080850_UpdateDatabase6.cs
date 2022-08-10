using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaGrande.Migrations
{
    public partial class UpdateDatabase6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DrinkId",
                schema: "18118057",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_DrinkId",
                schema: "18118057",
                table: "ShoppingCart",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Drink_DrinkId",
                schema: "18118057",
                table: "ShoppingCart",
                column: "DrinkId",
                principalSchema: "18118057",
                principalTable: "Drink",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Drink_DrinkId",
                schema: "18118057",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_DrinkId",
                schema: "18118057",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                schema: "18118057",
                table: "ShoppingCart");
        }
    }
}
