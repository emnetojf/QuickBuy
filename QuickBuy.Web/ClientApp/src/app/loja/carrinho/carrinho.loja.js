"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var CarrinhoLoja = /** @class */ (function () {
    function CarrinhoLoja() {
        this.produtos = [];
    }
    CarrinhoLoja.prototype.adiconarProduto = function (produto) {
        var produtolocalStorage = localStorage.getItem("produtolocalStorage");
        // se já existir um item no "produtolocalStorage" adiciona os itens na variável "produtos"
        if (produtolocalStorage) {
            this.produtos = JSON.parse(produtolocalStorage);
        }
        //adiciona o novo item
        this.produtos.push(produto);
        localStorage.setItem("produtolocalStorage", JSON.stringify(this.produtos));
    };
    CarrinhoLoja.prototype.obterProdutos = function () {
        var produtolocalStorage = localStorage.getItem("produtolocalStorage");
        if (produtolocalStorage) {
            return JSON.parse(produtolocalStorage);
        }
    };
    CarrinhoLoja.prototype.removerProduto = function (produto) {
    };
    return CarrinhoLoja;
}());
exports.CarrinhoLoja = CarrinhoLoja;
//# sourceMappingURL=carrinho.loja.js.map