using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayers.DataAccess;
using NLayers.Entites.Entities;

namespace NLayers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomovilsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutomovilsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Automovils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automovil>>> GetAutomoviles()
        {
            return await _context.Automoviles.ToListAsync();
        }

        // GET: api/Automovils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automovil>> GetAutomovil(int id)
        {
            var automovil = await _context.Automoviles.FindAsync(id);

            if (automovil == null)
            {
                return NotFound();
            }

            return automovil;
        }

        // PUT: api/Automovils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomovil(int id, Automovil automovil)
        {
            if (id != automovil.Id)
            {
                return BadRequest();
            }

            _context.Entry(automovil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomovilExists(id))
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

        // POST: api/Automovils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Automovil>> PostAutomovil(Automovil automovil)
        {
            _context.Automoviles.Add(automovil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutomovil", new { id = automovil.Id }, automovil);
        }

        // DELETE: api/Automovils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutomovil(int id)
        {
            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil == null)
            {
                return NotFound();
            }

            _context.Automoviles.Remove(automovil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutomovilExists(int id)
        {
            return _context.Automoviles.Any(e => e.Id == id);
        }
    }
}
