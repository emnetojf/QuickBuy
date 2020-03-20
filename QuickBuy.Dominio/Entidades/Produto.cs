namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int IdProd { get; set; }
        public string strNome { get; set; }
        public string strDescricao { get; set; }
        public decimal decPreco { get; set; }

        public override void Validate()
        {
            LimpaMsgValidacao();

            if (string.IsNullOrEmpty(strNome))
                AdicMsg("Informe o Nome!");

            if (string.IsNullOrEmpty(strDescricao))
                AdicMsg("Informe a Descrição!");

            if (decPreco == 0)
                AdicMsg("Informe o Preço!");
        }
    }
}
