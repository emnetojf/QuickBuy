import { Component, OnInit } from "@angular/core";
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { Produto } from "../../modelo/produto";
import { CarrinhoLoja } from "../carrinho/carrinho.loja";

@Component({
  selector: "efetivar-loja",
  templateUrl: "./efetivar.loja.component.html",
  styleUrls: ["./efetivar.loja.component.css"]
})

export class LojaEfetivarComponent implements OnInit {

  public carrinhoCompras: CarrinhoLoja;
  public produtos: Produto[];
  public Total: number;

  constructor(private produtoServico: ProdutoServico) {    
  }

  ngOnInit(): void {
    this.carrinhoCompras = new CarrinhoLoja();
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizaTotalPreco();
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
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizaTotalPreco();
  }

  public atualizaTotalPreco() {
    // Método reduce varre o array de objetos
    this.Total = this.produtos.reduce((acc, produto) => acc + produto.douPreco, 0); 
  }
}
