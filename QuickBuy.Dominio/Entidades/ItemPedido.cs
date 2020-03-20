namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int IdItemPed { get; set; }
        public int ProdId { get; set; }
        public int intQuant { get; set; }

        public override void Validate()
        {
            LimpaMsgValidacao();

            if (ProdId == 0)
                AdicMsg("Informe o produto!");

            if (intQuant == 0)
                AdicMsg("Informe a quantidade do produto!");
        }
    }
}
