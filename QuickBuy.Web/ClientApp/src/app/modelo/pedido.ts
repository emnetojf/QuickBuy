import { ItemPedido } from "./itempedido";

export class Pedido {
  idPed: number;
  UsuarioID: number;
  dtPedido: Date;
  dtEntrega: Date;
  strCEP: string;
  strUF: string;
  strCidade: string;
  strEnd: string;
  intNumEnd: number;
  PagtoID: number;
  ItemPedidos: ItemPedido[];

  constructor() {
    this.dtPedido = new Date();
    this.ItemPedidos = [];
  } 
}
