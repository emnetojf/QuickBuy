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
            builder.HasKey(prod => prod.idProd);

            // Builder utiliza padrão fluent
            builder.Property(prod => prod.strDescricao).IsRequired().HasMaxLength(400);
            builder.Property(prod => prod.strNome).IsRequired().HasMaxLength(50);
            builder.Property(prod => prod.douPreco).IsRequired().HasColumnType("float");          
        }
    }
}
