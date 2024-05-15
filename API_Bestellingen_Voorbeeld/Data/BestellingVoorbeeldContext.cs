using API_Bestellingen_Voorbeeld.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Bestellingen_Voorbeeld.Data
{
    public class BestellingVoorbeeldContext : DbContext
    {
        public BestellingVoorbeeldContext(DbContextOptions<BestellingVoorbeeldContext> options) : base(options) { }

        public DbSet<Product> Producten { get; set; } = default!;
        public DbSet<Bestellinglijn> Bestellinglijnen { get; set; } = default!;
        public DbSet<Bestelling> Bestellingen { get; set; } = default!;
        public DbSet<Gebruiker> Gebruikers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product").Property(p => p.Prijs).HasColumnType("decimal");
            modelBuilder.Entity<Bestellinglijn>().ToTable("Bestellinglijn");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");

            modelBuilder.Entity<Bestellinglijn>()
                .HasOne(bl => bl.Bestelling)
                .WithMany(b => b.Bestellinglijnen)
                .HasForeignKey(bl => bl.BestellingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bestellinglijn>()
                .HasOne(bl => bl.Product)
                .WithMany(p => p.Bestellinglijnen)
                .HasForeignKey(bl => bl.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bestelling>()
                .HasOne(b => b.Gebruiker)
                .WithMany(g => g.Bestellingen)
                .HasForeignKey(b => b.GebruikerId)
                .OnDelete(DeleteBehavior.Restrict);

            //Herzien van relaties?? Tabellen kunnen nu terug automatisch aangemaakt worden
        }
    }
}
