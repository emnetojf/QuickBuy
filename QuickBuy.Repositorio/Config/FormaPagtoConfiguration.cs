using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.ObjetoValor;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class FormaPagtoConfiguration : IEntityTypeConfiguration<FormaPagto>
    {
        public void Configure(EntityTypeBuilder<FormaPagto> builder)
        {
            builder.HasKey(pagto => pagto.IdPagto);

            // Builder utiliza padrão fluent
            builder.Property(pagto => pagto.strDescricao).IsRequired().HasMaxLength(100);
            builder.Property(pagto => pagto.strNome).IsRequired().HasMaxLength(50);
        }
    }
}
