using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _msgValidacao { get; set; }
        
        private List<string> msgValidacao { get { return _msgValidacao ?? (_msgValidacao = new List<string>()); } }
       
        protected void AdicMsg(string msg) { msgValidacao.Add(msg); }
        protected void LimpaMsgValidacao() { msgValidacao.Clear(); }
        
        public string ObterMsgValidacao()
        {
            return string.Join(" - ", msgValidacao);
        }

        public abstract void Validate();

        public bool Validado { get { return !msgValidacao.Any();  } }
    }
}
