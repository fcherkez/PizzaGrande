using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaGrande.Migrations
{
    public partial class UpdateDatabase5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                schema: "18118057",
                table: "Drink",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                schema: "18118057",
                table: "Drink");
        }
    }
}
