using API_Bestellingen_Voorbeeld.Data;
using API_Bestellingen_Voorbeeld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Bestellingen_Voorbeeld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellinglijnController : ControllerBase
    {
        private readonly ILogger<BestellinglijnController> _logger;
        private readonly BestellingVoorbeeldContext _context;

        public BestellinglijnController(ILogger<BestellinglijnController> logger, BestellingVoorbeeldContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestellinglijn>>> GetBestellinglijnen()
        {
            if (_context.Bestellinglijnen == null)
                return NotFound();

            List<Bestellinglijn> bestellinglijnen = await _context.Bestellinglijnen.ToListAsync();

            return Ok(bestellinglijnen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bestellinglijn>> GetBestellinglijn(int id)
        {
            if (_context.Bestellinglijnen == null)
                return NotFound();

            Bestellinglijn? bestellinglijn = await _context.Bestellinglijnen.FindAsync(id);

            if (bestellinglijn == null)
                return NotFound();

            return Ok(bestellinglijn);
        }

        [HttpPost]
        public async Task<ActionResult<Bestellinglijn>> CreateBestellinglijn(Bestellinglijn bestellinglijn)
        {
            if (_context.Bestellinglijnen == null)
                return NotFound();

            _context.Bestellinglijnen.Add(bestellinglijn);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Bestellinglijn),
                new { id = bestellinglijn.Id }
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBestellinglijn(long id, Bestellinglijn bestellinglijn)
        {
            if (id != bestellinglijn.Id)
                return BadRequest();

            _context.Entry(bestellinglijn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bestellinglijnen.Any(p => p.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestellinglijn(int id)
        {
            if (_context.Bestellinglijnen == null)
                return NotFound();

            Bestellinglijn? bestellinglijn = await _context.Bestellinglijnen.FindAsync(id);

            if (bestellinglijn == null)
                return NotFound();

            _context.Bestellinglijnen.Remove(bestellinglijn);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
