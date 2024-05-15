namespace API_Bestellingen_Voorbeeld.Models
{
    public class Bestellinglijn
    {
        public int Id { get; set; }
        public int BestellingId { get; set; }
        public int ProductId { get; set; }
        public int Aantal { get; set; }

        public Bestelling? Bestelling { get; set; }
        public Product? Product { get; set; }
    }
}
