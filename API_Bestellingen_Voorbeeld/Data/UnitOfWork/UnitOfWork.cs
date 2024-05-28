using API_Bestellingen_Voorbeeld.Data.Repositories;
using API_Bestellingen_Voorbeeld.Models;
using System.Numerics;

namespace API_Bestellingen_Voorbeeld.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BestellingVoorbeeldContext _context;
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<Gebruiker> _gebruikerRepository;
        private IGenericRepository<Bestelling> _bestellingRepository;
        private IGenericRepository<Bestellinglijn> _bestellinglijnRepository;

        public UnitOfWork(BestellingVoorbeeldContext context)
        {
            _context = context;
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new GenericRepository<Product>(_context);

                return _productRepository;
            }
        }
        
        public IGenericRepository<Gebruiker> GebruikerRepository
        {
            get
            {
                if (this._gebruikerRepository == null)
                    this._gebruikerRepository = new GenericRepository<Gebruiker>(_context);

                return _gebruikerRepository;
            }
        }

        public IGenericRepository<Bestelling> BestellingRepository
        {
            get
            {
                if (this._bestellingRepository == null)
                    this._bestellingRepository = new GenericRepository<Bestelling>(_context);

                return _bestellingRepository;
            }
        }

        public IGenericRepository<Bestellinglijn> BestellinglijnRepository
        {
            get
            {
                if (this._bestellinglijnRepository == null)
                    this._bestellinglijnRepository = new GenericRepository<Bestellinglijn>(_context);

                return _bestellinglijnRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
