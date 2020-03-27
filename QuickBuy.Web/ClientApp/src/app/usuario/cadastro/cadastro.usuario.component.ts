import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "cadastro-usuario",
  templateUrl: "./cadastro.usuario.component.html",
  styleUrls: ["./cadastro.usuario.component.css"]
})

export class CadastroUsuarioComponent implements OnInit {

  public usuario: Usuario;
  public msgErro: string;
  public ativar_spinner: boolean;
  public usuarioCadastrado: boolean;


  constructor(private usuarioServico: UsuarioServico) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  public cadastrar() {
    this.ativar_spinner = true;

    this.usuarioServico.cadastrarUsuario(this.usuario).subscribe(
      usuariojson => {
        this.usuarioCadastrado = true;
        this.msgErro = "";
      },
      err => {
        console.log(err.error);
        this.msgErro = err.error;
        this.ativar_spinner = false;
      }
    );

    this.ativar_spinner = false;
  }
    
}
