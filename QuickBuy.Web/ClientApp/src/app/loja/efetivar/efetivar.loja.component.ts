import { Component, OnInit } from "@angular/core";
import { Produto } from "../../modelo/produto";
import { CarrinhoLoja } from "../carrinho/carrinho.loja";
import { Router } from "@angular/router";
import { Pedido } from "../../modelo/pedido";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { ItemPedido } from "../../modelo/itempedido";
import { PedidoServico } from "../../servicos/pedido/pedido.servico";
import { Usuario } from "../../modelo/usuario";

@Component({
  selector: "efetivar-loja",
  templateUrl: "./efetivar.loja.component.html",
  styleUrls: ["./efetivar.loja.component.css"]
})

export class LojaEfetivarComponent implements OnInit {

  public usuario: Usuario;
  public carrinhoCompras: CarrinhoLoja;
  public produtos: Produto[];
  public Total: number;

  constructor(private usuarioServico: UsuarioServico, private pedidoServico: PedidoServico, private router: Router) {    
  }

  ngOnInit(): void {
    this.usuario = this.usuarioServico.usuario;
    this.carrinhoCompras = new CarrinhoLoja();
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizaTotalPreco();

    console.log(this.usuario);
    console.log(this.produtos);
    
  }

  public atualizaPreco(produto: Produto, quant: number) {
    if (!produto.douPrecoOrig) {
      produto.douPrecoOrig = produto.douPreco;
    }

    if (quant <= 0) {
      quant = 1;
      produto.numQuant = quant;
    } 

    produto.douPreco = produto.douPrecoOrig * quant;

    this.carrinhoCompras.atualizarProduto(this.produtos);
    this.atualizaTotalPreco();
  }

  public remover(produto: Produto) {
    this.carrinhoCompras.removerProduto(produto)
    //this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizaTotalPreco();

    if (this.produtos.length <= 0) {
      this.router.navigate(['/'])
    }

  }

  public atualizaTotalPreco() {
    // Método reduce varre o array de objetos
    this.Total = this.produtos.reduce((acc, produto) => acc + produto.douPreco, 0); 
  }

  public efetivarCompra() {
    let pedido = this.criarPedido();

    this.pedidoServico.efetivarCompra(pedido).subscribe(
      pedidoRealizado => {
        console.log(pedido)
        sessionStorage.setItem("pedido", JSON.stringify(pedidoRealizado));
        this.produtos = [];
        this.carrinhoCompras.limparCarrinhoCompras();
        this.router.navigate(["/compra-realizada"]);
      },
      e => {
        console.log(e.error);
      }
    );

  }

  public criarPedido(): Pedido {
    let pedido = new Pedido();

    pedido.UsuarioID = 1 // this.usuario.IdUsr;
    pedido.dtEntrega = new Date();
    pedido.PagtoID = 1;
    pedido.strCEP = "36016-010";
    pedido.strCidade = "Juiz de fora";
    pedido.strEnd = "rua x";
    pedido.intNumEnd = 12;
    pedido.strUF = "MG";

    for (let prod of this.produtos) {
      let itemPedido = new ItemPedido();
      itemPedido.ProdId = 1 //prod.IdProd;

      if (!prod.numQuant)
        prod.numQuant = 1;

      itemPedido.numQuant = prod.numQuant;

      // Relacionar Pedido aos itenpedido
      pedido.ItemPedidos.push(itemPedido);
    }
    return pedido;
  }

}
