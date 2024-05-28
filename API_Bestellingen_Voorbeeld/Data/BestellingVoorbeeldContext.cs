using API_Bestellingen_Voorbeeld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Bestellingen)
                .WithMany(b => b.Producten)
                .UsingEntity<Bestellinglijn>();

            modelBuilder.Entity<Bestelling>()
                .HasOne(b => b.Gebruiker)
                .WithMany(g => g.Bestellingen)
                .HasForeignKey(b => b.GebruikerId)
                .OnDelete(DeleteBehavior.Restrict);

            //Herzien van relaties?? Tabellen kunnen nu terug automatisch aangemaakt worden
        }
    }
}
