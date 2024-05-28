using API_Bestellingen_Voorbeeld.Data;
using API_Bestellingen_Voorbeeld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Bestellingen_Voorbeeld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly ILogger<GebruikerController> _logger;
        private readonly BestellingVoorbeeldContext _context;

        public GebruikerController(ILogger<GebruikerController> logger, BestellingVoorbeeldContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gebruiker>>> GetGebruiker()
        {
            if (_context.Gebruikers == null)
                return NotFound();

            List<Gebruiker> gebruikers = await _context.Gebruikers.ToListAsync();

            return Ok(gebruikers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gebruiker>> GetGebruiker(int id)
        {
            if (_context.Gebruikers == null)
                return NotFound();

            Gebruiker? gebruiker = await _context.Gebruikers.FindAsync(id);

            if (gebruiker == null)
                return NotFound();

            return Ok(gebruiker);
        }

        [HttpPost]
        public async Task<ActionResult<Gebruiker>> CreateGebruiker(Gebruiker gebruiker)
        {
            if (_context.Gebruikers == null)
                return NotFound();

            _context.Gebruikers.Add(gebruiker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Gebruiker),
                new { id = gebruiker.Id }
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGebruiker(long id, Gebruiker gebruiker)
        {
            if (id != gebruiker.Id)
                return BadRequest();

            _context.Entry(gebruiker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Gebruikers.Any(p => p.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGebruiker(int id)
        {
            if (_context.Gebruikers == null)
                return NotFound();

            Gebruiker? gebruiker = await _context.Gebruikers.FindAsync(id);

            if (gebruiker == null)
                return NotFound();

            _context.Gebruikers.Remove(gebruiker);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
