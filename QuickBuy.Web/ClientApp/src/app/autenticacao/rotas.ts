import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
//import { ProdutoComponent } from "../produtos/produto.component";
import { UsuarioServico } from "../servicos/usuario/usuario.servico";


@Injectable({
  providedIn: 'root'
})

export class rotas implements CanActivate {

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    //Usuario Autenticado
    if (this.usuarioServico.usuario_autenticado()) {
      return true;
    }

    this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
