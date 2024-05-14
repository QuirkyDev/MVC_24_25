using API_Bestellingen_Voorbeeld.Data;
using API_Bestellingen_Voorbeeld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Bestellingen_Voorbeeld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BestellingVoorbeeldContext _context;

        public ProductController(ILogger<WeatherForecastController> logger, BestellingVoorbeeldContext context)
        {
            _logger = logger;
            _context = context;
        }

        
    }
}
