using QuickBuy.Dominio.Enumerados;

namespace QuickBuy.Dominio.ObjetoValor
{
    public class FormaPagto
    {
        public int IdPagto { get; set; }
        public string strNome { get; set; }
        public string strDescricao { get; set; }

        
        public bool EhBoleto { get { return IdPagto == (int) TipoFormPagtoEnum.Boleto; } }
        public bool EhCartaoCred { get { return IdPagto == (int)TipoFormPagtoEnum.CartaoCred; } }
        public bool EhDeposito { get { return IdPagto == (int)TipoFormPagtoEnum.Deposito; } }
        public bool NaoDefinido { get { return IdPagto == (int)TipoFormPagtoEnum.NaoDefinido; } }
    }
}
