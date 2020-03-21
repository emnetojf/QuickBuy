using QuickBuy.Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int IdPed { get; set; }
        
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }

        public DateTime dtPedido { get; set; }
        public DateTime dtEntrega { get; set; }
        public string strCEP { get; set; }
        public string strUF { get; set; }
        public string strCidade { get; set; }
        public string strEnd { get; set; }
        public int intNumEnd { get; set; }

        public int PagtoID { get; set; }
        public FormaPagto Pagto { get; set; }

        public ICollection<ItemPedido> ItemPedidos { get; set; }

        public override void Validate()
        {
            LimpaMsgValidacao();

            if (!ItemPedidos.Any())
                AdicMsg("Não existem itens no pedido!");

            if (string.IsNullOrEmpty(strCEP))
                AdicMsg("Informe o CEP!");

            if (string.IsNullOrEmpty(strCidade))
                AdicMsg("Informe a Cidade!");

            if (string.IsNullOrEmpty(strUF))
                AdicMsg("Informe a UF!");

            if (string.IsNullOrEmpty(strEnd))
                AdicMsg("Informe o endereço!");

            if (intNumEnd == 0)
                AdicMsg("Informe o número endereço!");

            if (PagtoID == 0)
                AdicMsg("Informe o número endereço!");
        }
    }
}
