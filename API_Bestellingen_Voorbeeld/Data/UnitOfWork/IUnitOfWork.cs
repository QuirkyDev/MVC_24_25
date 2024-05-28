using API_Bestellingen_Voorbeeld.Data.Repositories;
using API_Bestellingen_Voorbeeld.Models;
using System.Numerics;

namespace API_Bestellingen_Voorbeeld.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Gebruiker> GebruikerRepository { get; }
        IGenericRepository<Bestelling> BestellingRepository { get; }
        IGenericRepository<Bestellinglijn> BestellinglijnRepository { get; }
        public void SaveChanges();
    }
}
