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
    public class MarkeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarkeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Marke
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marke>>> GetMarke()
        {
            return await _context.Marke.ToListAsync();
        }

        // GET: api/Marke/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marke>> GetMarke(int id)
        {
            var marke = await _context.Marke.FindAsync(id);

            if (marke == null)
            {
                return NotFound();
            }

            return marke;
        }

        // PUT: api/Marke/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarke(int id, Marke marke)
        {
            if (id != marke.Id)
            {
                return BadRequest();
            }

            _context.Entry(marke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkeExists(id))
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

        // POST: api/Marke
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marke>> PostMarke(Marke marke)
        {
            _context.Marke.Add(marke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarke", new { id = marke.Id }, marke);
        }

        // DELETE: api/Marke/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarke(int id)
        {
            var marke = await _context.Marke.FindAsync(id);
            if (marke == null)
            {
                return NotFound();
            }

            _context.Marke.Remove(marke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarkeExists(int id)
        {
            return _context.Marke.Any(e => e.Id == id);
        }
    }
}
