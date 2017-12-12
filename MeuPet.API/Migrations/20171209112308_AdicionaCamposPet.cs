using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MeuPet.API.Migrations
{
    public partial class AdicionaCamposPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Raca",
                table: "Pet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Raca",
                table: "Pet");
        }
    }
}
