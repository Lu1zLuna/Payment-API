namespace PaymentAPI.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
            
        }

        #region CriacaoDasTabelas

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        #endregion

        // Método que configura precisão de variáveis do tipo decimal
        protected override void ConfigureConventions
            (ModelConfigurationBuilder configurationBuilder) {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }
    }
}
