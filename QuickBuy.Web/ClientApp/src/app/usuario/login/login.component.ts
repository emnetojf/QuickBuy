import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})

export class LoginComponent implements OnInit {
   
  public usuario;
  public returnUrl: string; 
  

  constructor(private router: Router, private activatedRouter: ActivatedRoute) {
    this.usuario = new Usuario();    
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
  }
  
  entrar() {
    if (this.usuario.strEmail == "email@email.com" && this.usuario.strSenha == "123") {
      sessionStorage.setItem("usuario-autenticado", "1");
      this.router.navigate([this.returnUrl]);
    }

  }  
}
