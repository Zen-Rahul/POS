using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Api.Migrations
{
    public partial class CorrectedCheeseOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_CheeseOptions_CheeseId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_CheeseId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "CheeseId",
                table: "Pizzas");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "CheeseOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheeseOptions_PizzaId",
                table: "CheeseOptions",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheeseOptions_Pizzas_PizzaId",
                table: "CheeseOptions",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheeseOptions_Pizzas_PizzaId",
                table: "CheeseOptions");

            migrationBuilder.DropIndex(
                name: "IX_CheeseOptions_PizzaId",
                table: "CheeseOptions");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "CheeseOptions");

            migrationBuilder.AddColumn<int>(
                name: "CheeseId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CheeseId",
                table: "Pizzas",
                column: "CheeseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_CheeseOptions_CheeseId",
                table: "Pizzas",
                column: "CheeseId",
                principalTable: "CheeseOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
