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
    public class TienIchsController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public TienIchsController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/TienIchs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TienIchs>>> GetTienIchs()
        {
            return await _context.TienIchs.ToListAsync();
        }

        // GET: api/TienIchs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TienIchs>> GetTienIchs(int id)
        {
            var tienIchs = await _context.TienIchs.FindAsync(id);

            if (tienIchs == null)
            {
                return NotFound();
            }

            return tienIchs;
        }

        // PUT: api/TienIchs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTienIchs(int id, TienIchs tienIchs)
        {
            if (id != tienIchs.Id)
            {
                return BadRequest();
            }

            _context.Entry(tienIchs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TienIchsExists(id))
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

        // POST: api/TienIchs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TienIchs>> PostTienIchs(TienIchs tienIchs)
        {
            _context.TienIchs.Add(tienIchs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTienIchs", new { id = tienIchs.Id }, tienIchs);
        }

        // DELETE: api/TienIchs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TienIchs>> DeleteTienIchs(int id)
        {
            var tienIchs = await _context.TienIchs.FindAsync(id);
            if (tienIchs == null)
            {
                return NotFound();
            }

            _context.TienIchs.Remove(tienIchs);
            await _context.SaveChangesAsync();

            return tienIchs;
        }

        private bool TienIchsExists(int id)
        {
            return _context.TienIchs.Any(e => e.Id == id);
        }
    }
}
