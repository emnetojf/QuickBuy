import { Component, OnInit } from "@angular/core"
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";
import { Router } from "@angular/router";

@Component({
  selector: "cadastro-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})

export class ProdutoComponent implements OnInit {
   
  public produto: Produto;
  public arqSelecionado: File;
  public ativar_spinner: boolean;
  public msgErro: string;
  public produtoCadastrado: boolean;

  constructor(private produtoServico: ProdutoServico, private router: Router) {

  }

  
  ngOnInit(): void {
    var produtoSession = sessionStorage.getItem('produtoSession')
    if (produtoSession)
    {
      this.produto = JSON.parse(produtoSession);
    }
    else
    {
      this.produto = new Produto();
    }
  }

  public cadastrar() {
    this.ativar_spinner = true;

    this.produtoServico.cadastrarProduto(this.produto).subscribe(
      produtojson => {
        this.produtoCadastrado = true;
        this.msgErro = "";
        this.ativar_spinner = false;
        sessionStorage.setItem('produtoSession', "");
        this.router.navigate(['pesquisa-produto'])
      },
      err => {
        console.log(err.error);
        this.msgErro = err.error;
        this.ativar_spinner = false;
      }
    );
  }

  public cancelarProduto() {
    sessionStorage.setItem('produtoSession', "");
    this.router.navigate(['/pesquisa-produto']);
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


}
