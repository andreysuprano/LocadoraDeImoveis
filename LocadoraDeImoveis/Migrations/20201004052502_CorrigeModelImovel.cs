using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeImoveis.Migrations
{
    public partial class CorrigeModelImovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corretor",
                table: "Imoveis");

            migrationBuilder.AddColumn<int>(
                name: "IdCorretor",
                table: "Contratos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCorretor",
                table: "Contratos");

            migrationBuilder.AddColumn<int>(
                name: "Corretor",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
