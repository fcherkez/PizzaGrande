using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaGrande.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                schema: "18118057",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                schema: "18118057",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                schema: "18118057",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                schema: "18118057",
                table: "ShoppingCart",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                schema: "18118057",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "CartId",
                schema: "18118057",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId",
                schema: "18118057",
                table: "ShoppingCart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                schema: "18118057",
                table: "ShoppingCart",
                column: "ShoppingCartId");
        }
    }
}
