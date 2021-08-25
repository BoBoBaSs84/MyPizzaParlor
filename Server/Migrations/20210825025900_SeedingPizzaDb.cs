using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaParlor.Server.Migrations
{
    public partial class SeedingPizzaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Price" },
                values: new object[] { 1, 8.99m });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Price" },
                values: new object[] { 2, 7.99m });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Price" },
                values: new object[] { 3, 9.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
