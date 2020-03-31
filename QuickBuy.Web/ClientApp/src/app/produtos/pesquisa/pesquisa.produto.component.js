"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
core_1.Component({
    selector: "pesquisa-produto",
    templateUrl: "./pesquisa.produto.component.html",
    styleUrls: ["./pesquisa.produto.component.css"]
});
var PesquisaProdutoComponent = /** @class */ (function () {
    function PesquisaProdutoComponent(produtoServico) {
        var _this = this;
        this.produtoServico = produtoServico;
        this.produtoServico.obterProdutos().subscribe(function (produtos) {
            _this.produtos = produtos;
        }, function (e) {
            console.log(e.error);
        });
    }
    PesquisaProdutoComponent.prototype.ngOnInit = function () {
    };
    return PesquisaProdutoComponent;
}());
exports.PesquisaProdutoComponent = PesquisaProdutoComponent;
//# sourceMappingURL=pesquisa.produto.component.js.map