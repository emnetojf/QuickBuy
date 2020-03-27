import { Component, OnInit } from "@angular/core"
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";

@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})

export class ProdutoComponent implements OnInit {
   
  public produto: Produto;
  public arqSelecionado: File;
  public ativar_spinner: boolean;

  constructor(private produtoServico: ProdutoServico) {

  }

  public inputChange(files: FileList) {
    this.arqSelecionado = files.item(0);
    this.ativar_spinner = true;
    this.produtoServico.enviarArq(this.arqSelecionado).subscribe(
      novoNomeArq => {
        this.produto.strNomeArq = novoNomeArq;
        console.log(novoNomeArq);
        this.ativar_spinner = false;
      },
      err => {
        console.log(err.error);
      }
    );
  }

  ngOnInit(): void {
    this.produto = new Produto();
  }

  public cadastrar() {

    this.produtoServico.cadastrarProduto(this.produto).subscribe(
      produtojson => {
        console.log(produtojson)
      },
      e => {
          console.log(e.err)
      }
    );
  }
}
