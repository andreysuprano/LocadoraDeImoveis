using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeImoveis.Migrations
{
    public partial class AddEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Imoveis");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Imoveis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Imoveis");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
