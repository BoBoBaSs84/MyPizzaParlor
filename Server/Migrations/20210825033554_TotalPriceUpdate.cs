using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaParlor.Server.Migrations
{
    public partial class TotalPriceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Order",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
