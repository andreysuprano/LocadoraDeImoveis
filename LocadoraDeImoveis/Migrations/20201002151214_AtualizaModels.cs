using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeImoveis.Migrations
{
    public partial class AtualizaModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Comissao",
                table: "TipoImovel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TipoImovel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Locatarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Locatarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Locatarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Locatarios",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RendaDisponivel",
                table: "Locatarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Locatarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Locatarios",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Imoveis",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Imoveis",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Corretor",
                table: "Imoveis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Imoveis",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Locado",
                table: "Imoveis",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoImovel",
                table: "Imoveis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Imoveis",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValorAluguel",
                table: "Imoveis",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cofeci",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Corretores",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ComissaoCorretor",
                table: "Contratos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                table: "Contratos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdImovel",
                table: "Contratos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLocatario",
                table: "Contratos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorAluguel",
                table: "Contratos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comissao",
                table: "TipoImovel");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TipoImovel");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "RendaDisponivel",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Locatarios");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Corretor",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Locado",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "TipoImovel",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "ValorAluguel",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "Cofeci",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Corretores");

            migrationBuilder.DropColumn(
                name: "ComissaoCorretor",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "IdImovel",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "IdLocatario",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "ValorAluguel",
                table: "Contratos");
        }
    }
}
