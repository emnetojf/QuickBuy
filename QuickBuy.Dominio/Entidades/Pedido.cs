using QuickBuy.Dominio.ObjetoValor;
using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    class Pedido
    {
        public int IdPed { get; set; }
        public int UsrID { get; set; }
        public DateTime dtPedido { get; set; }
        public DateTime dtEntrega { get; set; }
        public string strCEP { get; set; }
        public string strUF { get; set; }
        public string strCidade { get; set; }
        public string strEnd { get; set; }
        public int intNumEnd { get; set; }

        public int PagtoID { get; set; }
        public FormaPagto FormaPagto { get; set; }

        public ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
