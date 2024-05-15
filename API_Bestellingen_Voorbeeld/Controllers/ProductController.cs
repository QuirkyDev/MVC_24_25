using API_Bestellingen_Voorbeeld.Data;
using API_Bestellingen_Voorbeeld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Bestellingen_Voorbeeld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Toevoegen DTO's??

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BestellingVoorbeeldContext _context;

        public ProductController(ILogger<WeatherForecastController> logger, BestellingVoorbeeldContext context)
        {
            _logger = logger; //Gebruiken, maar hoe?
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducten() {
            //Is dit echt nodig??
            if (_context.Producten == null)
                return NotFound();

            List<Product> producten = await _context.Producten.ToListAsync();

            return Ok(producten);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            //Is dit echt nodig??
            if (_context.Bestellingen == null)
                return NotFound();

            Product? product = await _context.Producten.FindAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            //Is dit echt nodig??
            if (_context.Producten == null)
                return NotFound();

            _context.Producten.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Product),
                new { id = product.Id }
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Producten.Any(p => p.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //Is dit echt nodig??
            if (_context.Producten == null)
                return NotFound();

            Product? product = await _context.Producten.FindAsync(id);
            
            if (product == null)
                return NotFound();

            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
