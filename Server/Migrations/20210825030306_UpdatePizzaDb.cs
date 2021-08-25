using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaParlor.Server.Migrations
{
    public partial class UpdatePizzaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Spiciness",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Spiciness" },
                values: new object[] { "Pepperoni", 1 });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Margarita");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Spiciness" },
                values: new object[] { "Diabolo", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Spiciness",
                table: "Pizzas");
        }
    }
}
