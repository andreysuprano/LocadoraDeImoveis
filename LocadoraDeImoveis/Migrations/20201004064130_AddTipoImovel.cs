using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeImoveis.Migrations
{
    public partial class AddTipoImovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoImovel",
                table: "Imoveis");

            migrationBuilder.AddColumn<int>(
                name: "TipoImovelId",
                table: "Imoveis",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_TipoImovelId",
                table: "Imoveis",
                column: "TipoImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_TipoImovel_TipoImovelId",
                table: "Imoveis",
                column: "TipoImovelId",
                principalTable: "TipoImovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_TipoImovel_TipoImovelId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_TipoImovelId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "TipoImovelId",
                table: "Imoveis");

            migrationBuilder.AddColumn<int>(
                name: "TipoImovel",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
