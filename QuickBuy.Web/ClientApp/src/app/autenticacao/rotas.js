"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rotas = /** @class */ (function () {
    function rotas() {
    }
    rotas.prototype.canActivate = function (route, state) {
        //Usuario Autenticado
        return true;
    };
    return rotas;
}());
exports.rotas = rotas;
//# sourceMappingURL=rotas.js.map