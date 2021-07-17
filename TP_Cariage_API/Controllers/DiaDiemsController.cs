using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Cariage_API.Data;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaDiemsController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public DiaDiemsController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/DiaDiems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaDiems>>> GetDiemDens()
        {
            return await _context.DiaDiems.ToListAsync();
        }

        // GET: api/DiaDiems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaDiems>> GetDiaDiems(int id)
        {
            var diaDiems = await _context.DiaDiems.FindAsync(id);

            if (diaDiems == null)
            {
                return NotFound();
            }

            return diaDiems;
        }

        // PUT: api/DiaDiems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaDiems(int id, DiaDiems diaDiems)
        {
            if (id != diaDiems.Id)
            {
                return BadRequest();
            }

            _context.Entry(diaDiems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaDiemsExists(id))
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

        // POST: api/DiaDiems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DiaDiems>> PostDiaDiems(DiaDiems diaDiems)
        {
            _context.DiaDiems.Add(diaDiems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaDiems", new { id = diaDiems.Id }, diaDiems);
        }

        // DELETE: api/DiaDiems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiaDiems>> DeleteDiaDiems(int id)
        {
            var diaDiems = await _context.DiaDiems.FindAsync(id);
            if (diaDiems == null)
            {
                return NotFound();
            }

            _context.DiaDiems.Remove(diaDiems);
            await _context.SaveChangesAsync();

            return diaDiems;
        }

        private bool DiaDiemsExists(int id)
        {
            return _context.DiaDiems.Any(e => e.Id == id);
        }
    }
}
