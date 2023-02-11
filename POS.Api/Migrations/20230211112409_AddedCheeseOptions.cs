﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Api.Migrations
{
    public partial class AddedCheeseOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cheese",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ExtraCheese",
                table: "Pizzas");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Cheese",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExtraCheese",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
