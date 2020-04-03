import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';
import { CarrinhoLoja } from '../loja/carrinho/carrinho.loja';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
    
  isExpanded = false;
  public carrinhoCompras: CarrinhoLoja;

  ngOnInit(): void {
    this.carrinhoCompras = new CarrinhoLoja();
  }

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }

  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean {
    return this.usuarioServico.usuario_autenticado();
  }

  public usuarioAdmin(): boolean {
    return this.usuarioServico.usuario_admin();
  }
 
  sair() {
    this.usuarioServico.limpar_sessao();
    this.router.navigate(['/'])
  }

  get usuarioNome() {

    return this.usuarioServico.usuario.strNome;
  }

  public itensCarrinhoCompras(): boolean {
    return this.carrinhoCompras.itensCarrinhoCompras();
  }
}
