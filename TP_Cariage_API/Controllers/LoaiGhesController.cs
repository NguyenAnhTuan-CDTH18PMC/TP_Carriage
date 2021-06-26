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
    public class LoaiGhesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public LoaiGhesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/LoaiGhes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiGhes>>> GetLoaiGhes()
        {
            return await _context.LoaiGhes.ToListAsync();
        }

        // GET: api/LoaiGhes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiGhes>> GetLoaiGhes(int id)
        {
            var loaiGhes = await _context.LoaiGhes.FindAsync(id);

            if (loaiGhes == null)
            {
                return NotFound();
            }

            return loaiGhes;
        }

        // PUT: api/LoaiGhes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiGhes(int id, LoaiGhes loaiGhes)
        {
            if (id != loaiGhes.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaiGhes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiGhesExists(id))
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

        // POST: api/LoaiGhes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoaiGhes>> PostLoaiGhes(LoaiGhes loaiGhes)
        {
            _context.LoaiGhes.Add(loaiGhes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiGhes", new { id = loaiGhes.Id }, loaiGhes);
        }

        // DELETE: api/LoaiGhes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiGhes>> DeleteLoaiGhes(int id)
        {
            var loaiGhes = await _context.LoaiGhes.FindAsync(id);
            if (loaiGhes == null)
            {
                return NotFound();
            }

            _context.LoaiGhes.Remove(loaiGhes);
            await _context.SaveChangesAsync();

            return loaiGhes;
        }

        private bool LoaiGhesExists(int id)
        {
            return _context.LoaiGhes.Any(e => e.Id == id);
        }
    }
}
