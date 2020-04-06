import { Component, OnInit } from "@angular/core";
import { Pedido } from "../../modelo/pedido";

@Component({
  selector: "compra-realizada-loja",
  templateUrl: "./compra.realizada.loja.component.html"  
})

export class LojaCompraRealizadaComponent implements OnInit {

  public pedido: Pedido;   

  ngOnInit(): void {
    this.pedido = JSON.parse(sessionStorage.getItem("pedido"));  
  }  


}
