using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MeuPet.API.Migrations
{
    public partial class AdicionaUrlImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Agenda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_UsuarioId",
                table: "Agenda",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Usuario_UsuarioId",
                table: "Agenda",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Usuario_UsuarioId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_UsuarioId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Agenda");
        }
    }
}
