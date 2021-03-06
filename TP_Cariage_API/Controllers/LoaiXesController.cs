using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Cariage_API.Data;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public LoaiXesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/LoaiXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiXes>>> GetLoaiXes()
        {
            return await _context.LoaiXes.ToListAsync();
        }

        // GET: api/LoaiXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiXes>> GetLoaiXes(int id)
        {
            var loaiXes = await _context.LoaiXes.FindAsync(id);

            if (loaiXes == null)
            {
                return NotFound();
            }

            return loaiXes;
        }

        // PUT: api/LoaiXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutLoaiXes(int id, LoaiXes loaiXes)
        {
            if (id != loaiXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaiXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiXesExists(id))
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

        // POST: api/LoaiXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LoaiXes>> PostLoaiXes(LoaiXes loaiXes)
        {
            _context.LoaiXes.Add(loaiXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiXes", new { id = loaiXes.Id }, loaiXes);
        }

        // DELETE: api/LoaiXes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<LoaiXes>> DeleteLoaiXes(int id)
        {
            var loaiXes = await _context.LoaiXes.FindAsync(id);
            if (loaiXes == null)
            {
                return NotFound();
            }

            _context.LoaiXes.Remove(loaiXes);
            await _context.SaveChangesAsync();

            return loaiXes;
        }

        private bool LoaiXesExists(int id)
        {
            return _context.LoaiXes.Any(e => e.Id == id);
        }
    }
}
