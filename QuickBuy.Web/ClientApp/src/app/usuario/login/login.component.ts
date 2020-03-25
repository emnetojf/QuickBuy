import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { error } from "protractor";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})

export class LoginComponent implements OnInit {
   
  public usuario;
  public returnUrl: string;
  public mesgErro: string

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private usuarioServico: UsuarioServico) {
    this.usuario = new Usuario();    
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
  }
  
  entrar() {

    this.usuarioServico.verificarUsuario(this.usuario).subscribe(
      data => {
        var usuarioRetorno: Usuario;
        usuarioRetorno = data;
        sessionStorage.setItem("usuario-autenticado", "1");
        sessionStorage.setItem("email-usuario", usuarioRetorno.strEmail);

        if (this.returnUrl == null) {
          this.router.navigate(['/']);
        } else {
          this.router.navigate([this.returnUrl]);
        }
        
      },
      err => {
        console.log(err.error);
        this.mesgErro = err.error;
      }
    );
  }  
}
