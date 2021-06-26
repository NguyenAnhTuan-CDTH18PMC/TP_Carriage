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
    public class NhanXetsController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public NhanXetsController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/NhanXets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanXets>>> GetNhanXets()
        {
            return await _context.NhanXets.ToListAsync();
        }

        // GET: api/NhanXets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanXets>> GetNhanXets(int id)
        {
            var nhanXets = await _context.NhanXets.FindAsync(id);

            if (nhanXets == null)
            {
                return NotFound();
            }

            return nhanXets;
        }

        // PUT: api/NhanXets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanXets(int id, NhanXets nhanXets)
        {
            if (id != nhanXets.Id)
            {
                return BadRequest();
            }

            _context.Entry(nhanXets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanXetsExists(id))
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

        // POST: api/NhanXets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NhanXets>> PostNhanXets(NhanXets nhanXets)
        {
            _context.NhanXets.Add(nhanXets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhanXets", new { id = nhanXets.Id }, nhanXets);
        }

        // DELETE: api/NhanXets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NhanXets>> DeleteNhanXets(int id)
        {
            var nhanXets = await _context.NhanXets.FindAsync(id);
            if (nhanXets == null)
            {
                return NotFound();
            }

            _context.NhanXets.Remove(nhanXets);
            await _context.SaveChangesAsync();

            return nhanXets;
        }

        private bool NhanXetsExists(int id)
        {
            return _context.NhanXets.Any(e => e.Id == id);
        }
    }
}
