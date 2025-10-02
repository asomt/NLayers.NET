using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayers.API.Data1;
using NLayers.API.Models1;

namespace NLayers.API.Controllers
{
    [ApiController]
    [Route("api/v1/automovil")]
    public class AutomovilController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutomovilController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/v1/automovil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automovil>>> GetAutomoviles()
        {
            return await _context.Automoviles.ToListAsync();
        }

        // ✅ GET: api/v1/automovil/{id}
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

        // ✅ GET: api/v1/automovil/chasis/{numeroChasis}
        [HttpGet("chasis/{numeroChasis}")]
        public async Task<ActionResult<Automovil>> GetByChasis(string numeroChasis)
        {
            if (string.IsNullOrWhiteSpace(numeroChasis))
                return BadRequest("El número de chasis no puede estar vacío.");

            var automovil = await _context.Automoviles
                                          .FirstOrDefaultAsync(a => a.NumeroChasis == numeroChasis);

            if (automovil == null)
            {
                return NotFound();
            }

            return Ok(automovil);
        }

        // ✅ PUT: api/v1/automovil/{id}
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

        // ✅ POST: api/v1/automovil
        [HttpPost]
        public async Task<ActionResult<Automovil>> PostAutomovil(Automovil automovil)
        {
            _context.Automoviles.Add(automovil);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAutomovil), new { id = automovil.Id }, automovil);
        }

        // ✅ DELETE: api/v1/automovil/{id}
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
