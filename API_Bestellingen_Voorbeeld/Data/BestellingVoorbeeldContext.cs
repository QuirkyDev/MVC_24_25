using API_Bestellingen_Voorbeeld.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Bestellingen_Voorbeeld.Data
{
    public class BestellingVoorbeeldContext : DbContext
    {
        public BestellingVoorbeeldContext(DbContextOptions<BestellingVoorbeeldContext> options) : base(options) { }

        public DbSet<Product> Producten { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product").Property(p => p.Prijs).HasColumnType("decimal");
        }
    }
}
