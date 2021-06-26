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
    public class BenXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public BenXesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/BenXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BenXes>>> GetBenXes()
        {
            return await _context.BenXes.ToListAsync();
        }

        // GET: api/BenXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BenXes>> GetBenXes(int id)
        {
            var benXes = await _context.BenXes.FindAsync(id);

            if (benXes == null)
            {
                return NotFound();
            }

            return benXes;
        }

        // PUT: api/BenXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenXes(int id, BenXes benXes)
        {
            if (id != benXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(benXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenXesExists(id))
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

        // POST: api/BenXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BenXes>> PostBenXes(BenXes benXes)
        {
            _context.BenXes.Add(benXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenXes", new { id = benXes.Id }, benXes);
        }

        // DELETE: api/BenXes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BenXes>> DeleteBenXes(int id)
        {
            var benXes = await _context.BenXes.FindAsync(id);
            if (benXes == null)
            {
                return NotFound();
            }

            _context.BenXes.Remove(benXes);
            await _context.SaveChangesAsync();

            return benXes;
        }

        private bool BenXesExists(int id)
        {
            return _context.BenXes.Any(e => e.Id == id);
        }
    }
}
