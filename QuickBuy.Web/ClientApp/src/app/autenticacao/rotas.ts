import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { ProdutoComponent } from "../produtos/produto.component";


@Injectable({
  providedIn: 'root'
})

export class rotas implements CanActivate {

  constructor(private router: Router) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var autenticado = localStorage.getItem("usuario-autenticado");

    //Usuario Autenticado
    if (autenticado == "1") {
      return true;
    }

    this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
