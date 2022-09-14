using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreinamentoCSharp.Migrations
{
    public partial class SalaDataCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "treinamento");

            migrationBuilder.RenameTable(
                name: "Sala",
                newName: "Sala",
                newSchema: "treinamento");

            migrationBuilder.RenameTable(
                name: "Evento",
                newName: "Evento",
                newSchema: "treinamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                schema: "treinamento",
                table: "Sala",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                schema: "treinamento",
                table: "Sala");

            migrationBuilder.RenameTable(
                name: "Sala",
                schema: "treinamento",
                newName: "Sala");

            migrationBuilder.RenameTable(
                name: "Evento",
                schema: "treinamento",
                newName: "Evento");
        }
    }
}
