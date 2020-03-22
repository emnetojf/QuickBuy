using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(usr => usr.IdUsr);

            // Builder utiliza padrão fluent
            builder.Property(usr => usr.strEmail).IsRequired().HasMaxLength(50);
            builder.Property(usr => usr.strNome).IsRequired().HasMaxLength(50);
            builder.Property(usr => usr.strSobrenome).IsRequired().HasMaxLength(50);
            builder.Property(usr => usr.strSenha).IsRequired().HasMaxLength(400);

            builder.HasMany(usr => usr.Pedidos).WithOne(ped => ped.Usuario);
        }
    }
}
