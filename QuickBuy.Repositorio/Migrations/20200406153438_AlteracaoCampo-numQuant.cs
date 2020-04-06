using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class AlteracaoCamponumQuant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "intQuant",
                table: "ItensPedido");

            migrationBuilder.AddColumn<int>(
                name: "numQuant",
                table: "ItensPedido",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numQuant",
                table: "ItensPedido");

            migrationBuilder.AddColumn<int>(
                name: "intQuant",
                table: "ItensPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
