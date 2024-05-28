using API_Bestellingen_Voorbeeld.Data;
using API_Bestellingen_Voorbeeld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Bestellingen_Voorbeeld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellingController : ControllerBase
    {
        private readonly ILogger<BestellingController> _logger;
        private readonly BestellingVoorbeeldContext _context;

        public BestellingController(ILogger<BestellingController> logger, BestellingVoorbeeldContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestelling>>> GetBestellingen()
        {
            if (_context.Bestellingen == null)
                return NotFound();

            List<Bestelling> bestellingen = await _context.Bestellingen.ToListAsync();

            return Ok(bestellingen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetBestelling(int id)
        {
            if (_context.Bestellingen == null)
                return NotFound();

            Bestelling? bestelling = await _context.Bestellingen.FindAsync(id);

            if (bestelling == null)
                return NotFound();

            return Ok(bestelling);
        }

        [HttpPost]
        public async Task<ActionResult<Bestelling>> CreateBestelling(Bestelling bestelling)
        {
            if (_context.Bestellingen == null)
                return NotFound();

            _context.Bestellingen.Add(bestelling);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Bestelling),
                new { id = bestelling.Id }
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBestelling(long id, Bestelling bestelling)
        {
            if (id != bestelling.Id)
                return BadRequest();

            _context.Entry(bestelling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bestellingen.Any(p => p.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestelling(int id)
        {
            if (_context.Bestellingen == null)
                return NotFound();

            Bestelling? bestelling = await _context.Bestellingen.FindAsync(id);

            if (bestelling == null)
                return NotFound();

            _context.Bestellingen.Remove(bestelling);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
