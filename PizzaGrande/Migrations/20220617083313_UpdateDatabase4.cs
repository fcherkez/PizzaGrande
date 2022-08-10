using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaGrande.Migrations
{
    public partial class UpdateDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "18118057",
                table: "Pizza",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "18118057",
                table: "Drink",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "18118057",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "18118057",
                table: "Drink");
        }
    }
}
