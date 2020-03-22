using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class CargaFormaPagto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FormaPagtos",
                columns: new[] { "IdPagto", "strDescricao", "strNome" },
                values: new object[] { 1, "Forma de Pagamento Boleto", "Boleto" });

            migrationBuilder.InsertData(
                table: "FormaPagtos",
                columns: new[] { "IdPagto", "strDescricao", "strNome" },
                values: new object[] { 2, "Forma de Pagamento Cartão Credito", "Cartao Credito" });

            migrationBuilder.InsertData(
                table: "FormaPagtos",
                columns: new[] { "IdPagto", "strDescricao", "strNome" },
                values: new object[] { 3, "Forma de Pagamento Depósito", "Depósito" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormaPagtos",
                keyColumn: "IdPagto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FormaPagtos",
                keyColumn: "IdPagto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FormaPagtos",
                keyColumn: "IdPagto",
                keyValue: 3);
        }
    }
}
