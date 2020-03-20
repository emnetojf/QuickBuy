using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    class Usuario
    {
        public int IdUsr { get; set; }
        public string strEmail { get; set; }
        public string strSenha { get; set; }
        public string strNome { get; set; }
        public string strSobrenome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
