namespace API_Bestellingen_Voorbeeld.Models
{
    public class Bestelling
    {
        public int Id { get; set; }
        public DateTime DatumBestelling { get; set; }
        public int GebruikerId { get; set; }


        public Gebruiker? Gebruiker { get; set; }
        public List<Bestellinglijn>? Bestellinglijnen { get; set; }
        public List<Product>? Producten { get; set; }
    }
}
