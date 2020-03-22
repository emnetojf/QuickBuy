using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class PrimeiraVersao : Migration
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
                    IdProd = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    strNome = table.Column<string>(maxLength: 50, nullable: false),
                    strDescricao = table.Column<string>(maxLength: 400, nullable: false),
                    decPreco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProd);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsr = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    strEmail = table.Column<string>(maxLength: 50, nullable: false),
                    strSenha = table.Column<string>(maxLength: 400, nullable: false),
                    strNome = table.Column<string>(maxLength: 50, nullable: false),
                    strSobrenome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsr);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPed = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Pedidos", x => x.IdPed);
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
                        principalColumn: "IdUsr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    IdItemPed = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdId = table.Column<int>(nullable: false),
                    intQuant = table.Column<int>(nullable: false),
                    PedidoIdPed = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.IdItemPed);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_PedidoIdPed",
                        column: x => x.PedidoIdPed,
                        principalTable: "Pedidos",
                        principalColumn: "IdPed",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoIdPed",
                table: "ItensPedido",
                column: "PedidoIdPed");

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
