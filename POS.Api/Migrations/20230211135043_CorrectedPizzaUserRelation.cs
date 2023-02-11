using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Api.Migrations
{
    public partial class CorrectedPizzaUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Users_UserId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Users_UserId",
                table: "Pizzas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
