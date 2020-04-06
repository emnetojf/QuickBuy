using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int idUsr { get; set; }
        public string strEmail { get; set; }
        public string strSenha { get; set; }
        public string strNome { get; set; }
        public string strSobrenome { get; set; }
        public bool booAdministrador { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            LimpaMsgValidacao();

            if (string.IsNullOrEmpty(strEmail))
                AdicMsg("Informe o email!");

            if (string.IsNullOrEmpty(strSenha))
                AdicMsg("Informe a Senha!");

            if (string.IsNullOrEmpty(strNome))
                AdicMsg("Informe o Nome!");

            if (string.IsNullOrEmpty(strSobrenome))
                AdicMsg("Informe o Sobrenome!");
        }
    }
}
