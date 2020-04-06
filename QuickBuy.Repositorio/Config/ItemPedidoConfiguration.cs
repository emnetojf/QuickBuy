using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(itens => itens.IdItemPed);

            // Builder utiliza padrão fluent
            builder.Property(itens => itens.ProdId).IsRequired();
            builder.Property(itens => itens.numQuant).IsRequired();
        }
    }
}
