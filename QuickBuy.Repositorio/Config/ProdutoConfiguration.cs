using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(prod => prod.IdProd);

            // Builder utiliza padrão fluent
            builder.Property(prod => prod.strDescricao).IsRequired().HasMaxLength(400).HasColumnType("nvarchar");
            builder.Property(prod => prod.strNome).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(prod => prod.decPreco).IsRequired().HasColumnType("decimal(6,2)");          
        }
    }
}
