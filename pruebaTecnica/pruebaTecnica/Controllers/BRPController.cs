using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaTecnica.Data;
using pruebaTecnica.Models;

namespace pruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BRPController: ControllerBase
    {
        private readonly BRPContext _context;

        public BRPController(BRPContext context)
        {
            _context = context;
        }

        // GET: api/BRP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BRP>>> GetBRPs([FromQuery] string search, [FromQuery] string country)
        {
            var query = _context.BRPs.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.BrpCode.Contains(search) || b.BrpName.Contains(search));
            }

            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(b => b.Country == country);
            }

            var result = await query.ToListAsync();

            if (result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        // GET: api/BRP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BRP>> GetBRP(int id)
        {
            var brp = await _context.BRPs.FindAsync(id);

            if (brp == null)
            {
                return NotFound();
            }

            return Ok(brp);
        }

        // POST: api/BRP
        [HttpPost]
        public async Task<ActionResult<BRP>> PostBRP(BRP brp)
        {
            _context.BRPs.Add(brp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBRP", new { id = brp.Id }, brp);
        }

        // PUT: api/BRP/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBRP(int id, BRP brp)
        {
            if (id != brp.Id)
            {
                return BadRequest();
            }

            _context.Entry(brp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BRPExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/BRP/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBRP(int id)
        {
            var brp = await _context.BRPs.FindAsync(id);
            if (brp == null)
            {
                return NotFound();
            }

            _context.BRPs.Remove(brp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BRPExists(int id)
        {
            return _context.BRPs.Any(e => e.Id == id);
        }
    }
}
