import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Pedido } from "../../modelo/pedido";

@Injectable({
  providedIn: "root"
})

export class PedidoServico implements OnInit {

  private baseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  ngOnInit(): void {
        throw new Error("Method not implemented.");
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public efetivarCompra(pedido: Pedido): Observable<number> {
    return this.http.post<number>(this.baseURL + "api/pedido/", JSON.stringify(pedido), { headers: this.headers });
  }
}
