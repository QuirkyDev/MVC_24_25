namespace API_Bestellingen_Voorbeeld.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }

        public List<Bestellinglijn>? Bestellinglijnen { get; set; }
        public List<Bestelling>? Bestellingen { get; set; }
    }
}
