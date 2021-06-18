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
    public class EnergydrinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnergydrinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Energydrinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Energydrinks>>> GetEnergydrinks()
        {
            return await _context.Energydrinks.ToListAsync();
        }

        // GET: api/Energydrinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Energydrinks>> GetEnergydrinks(int id)
        {
            var energydrinks = await _context.Energydrinks.FindAsync(id);

            if (energydrinks == null)
            {
                return NotFound();
            }

            return energydrinks;
        }

        // PUT: api/Energydrinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnergydrinks(int id, Energydrinks energydrinks)
        {
            if (id != energydrinks.Id)
            {
                return BadRequest();
            }

            _context.Entry(energydrinks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergydrinksExists(id))
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

        // POST: api/Energydrinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Energydrinks>> PostEnergydrinks(Energydrinks energydrinks)
        {
            _context.Energydrinks.Add(energydrinks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnergydrinks", new { id = energydrinks.Id }, energydrinks);
        }

        // DELETE: api/Energydrinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergydrinks(int id)
        {
            var energydrinks = await _context.Energydrinks.FindAsync(id);
            if (energydrinks == null)
            {
                return NotFound();
            }

            _context.Energydrinks.Remove(energydrinks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnergydrinksExists(int id)
        {
            return _context.Energydrinks.Any(e => e.Id == id);
        }
    }
}
