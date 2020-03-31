using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class AlteracaoPrecoProdutoFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "decPreco",
                table: "Produtos");

            migrationBuilder.AddColumn<float>(
                name: "douPreco",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "douPreco",
                table: "Produtos");

            migrationBuilder.AddColumn<decimal>(
                name: "decPreco",
                table: "Produtos",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
