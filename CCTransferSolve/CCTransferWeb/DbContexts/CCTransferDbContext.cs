using Microsoft.EntityFrameworkCore;
using CCTransferWeb.Models;

namespace CCTransferWeb.DbContexts
{
    public class CCTransferDbContext : DbContext
    {
        public CCTransferDbContext(DbContextOptions<CCTransferDbContext> options) : base(options) { }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<FactorConversion> FactorConversiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moneda>().HasData(
                new Moneda
                {
                    Id = 1,
                    NomMoneda = "Euro",
                    CodMoneda = "EUR"
                });
        }
    }
}