using Microsoft.EntityFrameworkCore;
using CCTransferApi.Models;

namespace CCTransferApi.DbContexts
{
    public class CCTransferDbContext : DbContext
    { 
        public CCTransferDbContext(DbContextOptions<CCTransferDbContext> options) : base(options) { }
        public DbSet<Moneda> Coins { get; set; }

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