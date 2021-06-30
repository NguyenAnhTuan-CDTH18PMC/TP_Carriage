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
    public class TienIchCuaXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public TienIchCuaXesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/TienIchCuaXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TienIchCuaXes>>> GetTienIchCuaXes()
        {
            return await _context.TienIchCuaXes.ToListAsync();
        }

        // GET: api/TienIchCuaXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TienIchCuaXes>> GetTienIchCuaXes(int id)
        {
            var tienIchCuaXes = await _context.TienIchCuaXes.FindAsync(id);

            if (tienIchCuaXes == null)
            {
                return NotFound();
            }

            return tienIchCuaXes;
        }

        // PUT: api/TienIchCuaXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTienIchCuaXes(int id, TienIchCuaXes tienIchCuaXes)
        {
            if (id != tienIchCuaXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(tienIchCuaXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TienIchCuaXesExists(id))
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

        // POST: api/TienIchCuaXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TienIchCuaXes>> PostTienIchCuaXes(TienIchCuaXes tienIchCuaXes)
        {
            _context.TienIchCuaXes.Add(tienIchCuaXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTienIchCuaXes", new { id = tienIchCuaXes.Id }, tienIchCuaXes);
        }

        // DELETE: api/TienIchCuaXes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TienIchCuaXes>> DeleteTienIchCuaXes(int id)
        {
            var tienIchCuaXes = await _context.TienIchCuaXes.FindAsync(id);
            if (tienIchCuaXes == null)
            {
                return NotFound();
            }

            _context.TienIchCuaXes.Remove(tienIchCuaXes);
            await _context.SaveChangesAsync();

            return tienIchCuaXes;
        }

        private bool TienIchCuaXesExists(int id)
        {
            return _context.TienIchCuaXes.Any(e => e.Id == id);
        }
    }
}
