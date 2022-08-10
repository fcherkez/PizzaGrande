using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaGrande.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                schema: "18118057",
                table: "Pizza",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                schema: "18118057",
                table: "OrderDetail",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                schema: "18118057",
                table: "Drink",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                schema: "18118057",
                table: "Pizza",
                type: "float",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                schema: "18118057",
                table: "OrderDetail",
                type: "float",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                schema: "18118057",
                table: "Drink",
                type: "float",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }
    }
}
