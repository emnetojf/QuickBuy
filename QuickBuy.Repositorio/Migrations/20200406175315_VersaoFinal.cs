using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class VersaoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaPagtos",
                columns: table => new
                {
                    IdPagto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    strNome = table.Column<string>(maxLength: 50, nullable: false),
                    strDescricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagtos", x => x.IdPagto);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idProd = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    strNome = table.Column<string>(maxLength: 50, nullable: false),
                    strDescricao = table.Column<string>(maxLength: 400, nullable: false),
                    douPreco = table.Column<float>(type: "float", nullable: false),
                    strNomeArq = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idProd);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsr = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    strEmail = table.Column<string>(maxLength: 50, nullable: false),
                    strSenha = table.Column<string>(maxLength: 400, nullable: false),
                    strNome = table.Column<string>(maxLength: 50, nullable: false),
                    strSobrenome = table.Column<string>(maxLength: 50, nullable: false),
                    booAdministrador = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsr);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    idPed = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    dtPedido = table.Column<DateTime>(nullable: false),
                    dtEntrega = table.Column<DateTime>(nullable: false),
                    strCEP = table.Column<string>(maxLength: 10, nullable: false),
                    strUF = table.Column<string>(maxLength: 5, nullable: false),
                    strCidade = table.Column<string>(maxLength: 30, nullable: false),
                    strEnd = table.Column<string>(maxLength: 50, nullable: false),
                    intNumEnd = table.Column<int>(nullable: false),
                    PagtoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.idPed);
                    table.ForeignKey(
                        name: "FK_Pedidos_FormaPagtos_PagtoID",
                        column: x => x.PagtoID,
                        principalTable: "FormaPagtos",
                        principalColumn: "IdPagto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "idUsr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    idItemPed = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdId = table.Column<int>(nullable: false),
                    numQuant = table.Column<int>(nullable: false),
                    PedidoidPed = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.idItemPed);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_PedidoidPed",
                        column: x => x.PedidoidPed,
                        principalTable: "Pedidos",
                        principalColumn: "idPed",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoidPed",
                table: "ItensPedido",
                column: "PedidoidPed");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PagtoID",
                table: "Pedidos",
                column: "PagtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioID",
                table: "Pedidos",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "FormaPagtos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
