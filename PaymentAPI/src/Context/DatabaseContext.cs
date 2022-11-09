using Microsoft.EntityFrameworkCore;
using PaymentAPI.src.Models;

namespace PaymentAPI.src.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
            
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Venda>(tabela => {
                tabela.HasKey(e => e.Id);
                tabela.HasMany(e => e.Pedidos).WithOne().HasForeignKey(p => p.Id);
            });
        }
    }
}
