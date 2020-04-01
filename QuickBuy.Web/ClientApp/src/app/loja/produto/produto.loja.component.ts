import { Component, OnInit } from "@angular/core";
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { Produto } from "../../modelo/produto";

@Component({
  selector: "produto-loja",
  templateUrl: "./produto.loja.component.html",
  styleUrls: ["./produto.loja.component.css"]
})

export class LojaProdutoComponent implements OnInit {

  public produto: Produto;

  constructor(private produtoServico: ProdutoServico) {
    //this.produtoServico.obterProdutos().subscribe(
    //  produtos => {
    //    this.produtos = produtos;
    //  },
    //  e => {
    //    console.log(e.error);
    //  }
    //);
  }

  ngOnInit(): void {
    var produtoDetalhe = sessionStorage.getItem("produtoDetalhe");

    if (produtoDetalhe) {
      this.produto = JSON.parse(produtoDetalhe);
    }
  }

}

