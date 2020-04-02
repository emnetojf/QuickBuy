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

  constructor(private produtoServico: ProdutoServico) {    
  }

  ngOnInit(): void {
    this.carrinhoCompras = new CarrinhoLoja();
    this.produtos = this.carrinhoCompras.obterProdutos();
  }

}
