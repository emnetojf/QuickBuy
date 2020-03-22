using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(ped => ped.IdPed);

            // Builder utiliza padrão fluent
            builder.Property(ped => ped.UsuarioID).IsRequired();
            builder.Property(ped => ped.PagtoID).IsRequired();
            builder.Property(ped => ped.strCEP).IsRequired().HasMaxLength(10);
            builder.Property(ped => ped.strCidade).IsRequired().HasMaxLength(30);
            builder.Property(ped => ped.strEnd).IsRequired().HasMaxLength(50);
            builder.Property(ped => ped.strUF).IsRequired().HasMaxLength(5);
            builder.Property(ped => ped.intNumEnd).IsRequired();
            builder.Property(ped => ped.dtPedido).IsRequired();
            builder.Property(ped => ped.dtEntrega).IsRequired();

          
        }
    }
}
