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
    public class LichTrinhsController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public LichTrinhsController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/LichTrinhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichTrinhs>>> GetLichTrinhs()
        {
            return await _context.LichTrinhs.ToListAsync();
        }

        // GET: api/LichTrinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LichTrinhs>> GetLichTrinhs(int id)
        {
            var lichTrinhs = await _context.LichTrinhs.FindAsync(id);
            lichTrinhs.DiemDens = await _context.DiemDens.FindAsync(lichTrinhs.DiemDenId);
            lichTrinhs.DiemDis = await _context.DiemDens.FindAsync(lichTrinhs.DiemDiId);
            if (lichTrinhs == null)
            {
                return NotFound();
            }

            return lichTrinhs;
        }

        // PUT: api/LichTrinhs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichTrinhs(int id, LichTrinhs lichTrinhs)
        {
            if (id != lichTrinhs.Id)
            {
                return BadRequest();
            }

            _context.Entry(lichTrinhs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichTrinhsExists(id))
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

        // POST: api/LichTrinhs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LichTrinhs>> PostLichTrinhs(LichTrinhs lichTrinhs)
        {
            _context.LichTrinhs.Add(lichTrinhs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLichTrinhs", new { id = lichTrinhs.Id }, lichTrinhs);
        }

        // DELETE: api/LichTrinhs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LichTrinhs>> DeleteLichTrinhs(int id)
        {
            var lichTrinhs = await _context.LichTrinhs.FindAsync(id);
            if (lichTrinhs == null)
            {
                return NotFound();
            }

            _context.LichTrinhs.Remove(lichTrinhs);
            await _context.SaveChangesAsync();

            return lichTrinhs;
        }

        private bool LichTrinhsExists(int id)
        {
            return _context.LichTrinhs.Any(e => e.Id == id);
        }
    }
}
