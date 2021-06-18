using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Energy_Shop.Data;
using Energy_Shop.Models;

namespace Energy_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeschmackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeschmackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Geschmack
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Geschmack>>> GetGeschmack()
        {
            return await _context.Geschmack.ToListAsync();
        }

        // GET: api/Geschmack/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Geschmack>> GetGeschmack(int id)
        {
            var geschmack = await _context.Geschmack.FindAsync(id);

            if (geschmack == null)
            {
                return NotFound();
            }

            return geschmack;
        }

        // PUT: api/Geschmack/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeschmack(int id, Geschmack geschmack)
        {
            if (id != geschmack.Id)
            {
                return BadRequest();
            }

            _context.Entry(geschmack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeschmackExists(id))
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

        // POST: api/Geschmack
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Geschmack>> PostGeschmack(Geschmack geschmack)
        {
            _context.Geschmack.Add(geschmack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeschmack", new { id = geschmack.Id }, geschmack);
        }

        // DELETE: api/Geschmack/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeschmack(int id)
        {
            var geschmack = await _context.Geschmack.FindAsync(id);
            if (geschmack == null)
            {
                return NotFound();
            }

            _context.Geschmack.Remove(geschmack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeschmackExists(int id)
        {
            return _context.Geschmack.Any(e => e.Id == id);
        }
    }
}
