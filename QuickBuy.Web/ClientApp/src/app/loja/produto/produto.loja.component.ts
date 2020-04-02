import { Component, OnInit } from "@angular/core";
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { Produto } from "../../modelo/produto";
import { Router } from "@angular/router";
import { CarrinhoLoja } from "../carrinho/carrinho.loja";

@Component({
  selector: "produto-loja",
  templateUrl: "./produto.loja.component.html",
  styleUrls: ["./produto.loja.component.css"]
})

export class LojaProdutoComponent implements OnInit {

  public produto: Produto;
  public carrinhoCompras: CarrinhoLoja;

  constructor(private produtoServico: ProdutoServico, private router: Router) {
  }

  ngOnInit(): void {
    this.carrinhoCompras = new CarrinhoLoja();

    var produtoDetalhe = sessionStorage.getItem("produtoDetalhe");

    if (produtoDetalhe) {
      this.produto = JSON.parse(produtoDetalhe);
    }
  }

  public comprar() {
    this.carrinhoCompras.adiconarProduto(this.produto);
    this.router.navigate(['/efetivar-loja']);
  }
}

