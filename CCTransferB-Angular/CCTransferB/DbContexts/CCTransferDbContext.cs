using Microsoft.EntityFrameworkCore;
using CCTransferB.Models;

namespace CCTransferB.DbContexts
{
    public class CCTransferDbContext : DbContext
    {
        public CCTransferDbContext(DbContextOptions<CCTransferDbContext> options) : base(options) { }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<FactorConversion> FactorConversiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<MonedaDto>().HasData(
            //    new Moneda { Id = 1, CodMoneda = "EUR", NomMoneda = "Euro" },
            //    new Moneda { Id = 2, CodMoneda = "USD", NomMoneda = "Dolar" },
            //    new Moneda { Id = 3, CodMoneda = "GBP", NomMoneda = "Libra" },
            //    new Moneda { Id = 4, CodMoneda = "SEK", NomMoneda = "Corona Sueca" },
            //    new Moneda { Id = 5, CodMoneda = "TRY", NomMoneda = "Lira Turca" },
            //    new Moneda { Id = 6, CodMoneda = "BGN", NomMoneda = "Lev" },
            //    new Moneda { Id = 7, CodMoneda = "ALL", NomMoneda = "Lek albanés" },
            //    new Moneda { Id = 8, CodMoneda = "AMD", NomMoneda = "Dram armenio" },
            //    new Moneda { Id = 9, CodMoneda = "AZN", NomMoneda = "Manat azeri" },
            //    new Moneda { Id = 10, CodMoneda = "HRK", NomMoneda = "kuna croata" });
        }
    }
}