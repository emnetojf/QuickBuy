using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoValor;
using QuickBuy.Repositorio.Config;

namespace QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<FormaPagto> FormaPagtos { get; set; }

        public QuickBuyContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Classes de Mapeamento
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagtoConfiguration());

            modelBuilder.Entity<FormaPagto>().HasData(
                new FormaPagto() {IdPagto = 1, strNome = "Boleto", strDescricao = "Forma de Pagamento Boleto" },
                new FormaPagto() { IdPagto = 2, strNome = "Cartao Credito", strDescricao = "Forma de Pagamento Cartão Credito" },
                new FormaPagto() { IdPagto = 3, strNome = "Depósito", strDescricao = "Forma de Pagamento Depósito" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
     
    
}
