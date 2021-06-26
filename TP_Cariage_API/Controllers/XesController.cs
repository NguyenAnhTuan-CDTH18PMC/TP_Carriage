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
    public class XesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public XesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/Xes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Xes>>> GetXes()
        {
            return await _context.Xes.ToListAsync();
        }

        // GET: api/Xes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Xes>> GetXes(int id)
        {
            var xes = await _context.Xes.FindAsync(id);

            if (xes == null)
            {
                return NotFound();
            }

            return xes;
        }

        // PUT: api/Xes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXes(int id, Xes xes)
        {
            if (id != xes.Id)
            {
                return BadRequest();
            }

            _context.Entry(xes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XesExists(id))
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

        // POST: api/Xes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Xes>> PostXes(Xes xes)
        {
            _context.Xes.Add(xes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXes", new { id = xes.Id }, xes);
        }

        // DELETE: api/Xes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Xes>> DeleteXes(int id)
        {
            var xes = await _context.Xes.FindAsync(id);
            if (xes == null)
            {
                return NotFound();
            }

            _context.Xes.Remove(xes);
            await _context.SaveChangesAsync();

            return xes;
        }

        private bool XesExists(int id)
        {
            return _context.Xes.Any(e => e.Id == id);
        }
    }
}
