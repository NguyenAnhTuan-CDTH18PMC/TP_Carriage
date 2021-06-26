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
    public class NhaXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public NhaXesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/NhaXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaXes>>> GetNhaXes()
        {
            return await _context.NhaXes.ToListAsync();
        }

        // GET: api/NhaXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaXes>> GetNhaXes(int id)
        {
            var nhaXes = await _context.NhaXes.FindAsync(id);

            if (nhaXes == null)
            {
                return NotFound();
            }

            return nhaXes;
        }

        // PUT: api/NhaXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhaXes(int id, NhaXes nhaXes)
        {
            if (id != nhaXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(nhaXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaXesExists(id))
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

        // POST: api/NhaXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NhaXes>> PostNhaXes(NhaXes nhaXes)
        {
            _context.NhaXes.Add(nhaXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhaXes", new { id = nhaXes.Id }, nhaXes);
        }

        // DELETE: api/NhaXes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NhaXes>> DeleteNhaXes(int id)
        {
            var nhaXes = await _context.NhaXes.FindAsync(id);
            if (nhaXes == null)
            {
                return NotFound();
            }

            _context.NhaXes.Remove(nhaXes);
            await _context.SaveChangesAsync();

            return nhaXes;
        }

        private bool NhaXesExists(int id)
        {
            return _context.NhaXes.Any(e => e.Id == id);
        }
    }
}
