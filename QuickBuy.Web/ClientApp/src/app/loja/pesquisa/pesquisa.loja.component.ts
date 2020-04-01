import { Component, OnInit } from "@angular/core"
import { ProdutoServico } from "../../servicos/produto/produto.servico";
import { Produto } from "../../modelo/produto";


@Component({
  selector: "pesquisa-loja",
  templateUrl: "./pesquisa.loja.component.html",
  styleUrls: ["./pesquisa.loja.component.css"]
})

export class LojaPesquisaComponent implements OnInit {

  public produtos: Produto[];

  constructor(private produtoServico: ProdutoServico) {
    this.produtoServico.obterProdutos().subscribe(
      produtos => {
        this.produtos = produtos;
      },
      e => {
        console.log(e.error);
      }
    );
  }

  ngOnInit(): void {

  }

}
