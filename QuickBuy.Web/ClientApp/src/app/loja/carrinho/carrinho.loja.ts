import { Produto } from "../../modelo/produto";

export class CarrinhoLoja {
  public produtos: Produto[] = [];
  public produtosAux: Produto[] = [];
  

  public adiconarProduto(produto: Produto) {
    var produtolocalStorage = localStorage.getItem("produtolocalStorage");

    // se já existir um item no "produtolocalStorage" adiciona os itens na variável "produtos"
    if (produtolocalStorage) {      
      this.produtos = JSON.parse(produtolocalStorage);       
    }    

    //adiciona o novo item
    this.produtos.push(produto);     
    localStorage.setItem("produtolocalStorage", JSON.stringify(this.produtos));

  }

  public obterProdutos(): Produto[] {
    var produtolocalStorage = localStorage.getItem("produtolocalStorage");

    if (produtolocalStorage) {
      return JSON.parse(produtolocalStorage);
    }    

  }

  public removerProduto(produto: Produto) {
    var produtolocalStorage = localStorage.getItem("produtolocalStorage");
    
    if (produtolocalStorage) {
      this.produtos = JSON.parse(produtolocalStorage);

      this.produtos = this.produtos.filter(prod => prod.strNome != produto.strNome);

      localStorage.setItem("produtolocalStorage", JSON.stringify(this.produtos));
    }            
  }

  public atualizarProduto(produtos: Produto[]) {
    localStorage.setItem("produtolocalStorage", JSON.stringify(produtos));
  }

}
