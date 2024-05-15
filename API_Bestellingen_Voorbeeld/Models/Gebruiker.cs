namespace API_Bestellingen_Voorbeeld.Models
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        public List<Bestelling>? Bestellingen { get; set; }
    }
}
