namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int IdProd { get; set; }
        public string strNome { get; set; }
        public string strDescricao { get; set; }
        public double douPreco { get; set; }
        public string strNomeArq { get; set; }

        public override void Validate()
        {
            LimpaMsgValidacao();

            if (string.IsNullOrEmpty(strNome))
                AdicMsg("Informe o Nome!");

            if (string.IsNullOrEmpty(strDescricao))
                AdicMsg("Informe a Descrição!");

            if (douPreco == 0)
                AdicMsg("Informe o Preço!");
        }
    }
}
