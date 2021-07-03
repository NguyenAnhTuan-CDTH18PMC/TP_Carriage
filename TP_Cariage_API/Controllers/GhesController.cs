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
    public class GhesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public GhesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/Ghes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ghes>>> GetGhes()
        {
            return await _context.Ghes.ToListAsync();
        }

        [HttpGet("ChuyenXes/{id}")]
        public async Task<ActionResult<IEnumerable<Ghes>>> GetGhesTheoChuyenXes(int id)
        {
            List<Ghes> result = new List<Ghes>();
            var chuyenXes = await _context.ChuyenXes.FindAsync(id);
            var Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
            List<Ghes> listGhe = await _context.Ghes.ToListAsync();
            if (listGhe == null)
            {
                return NotFound();
            }
            foreach(Ghes ghes in listGhe)
            {
                if (ghes.XeId == Xes.Id)
                {
                    result.Add(ghes);
                }
            }
            return Ok(result);
        }

        // GET: api/Ghes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ghes>> GetGhes(int id)
        {
            var ghes = await _context.Ghes.FindAsync(id);
            ghes.Xes = await _context.Xes.FindAsync(ghes.XeId);
            if (ghes == null)
            {
                return NotFound();
            }

            return ghes;
        }

        // PUT: api/Ghes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGhes(int id,Ghes request)
        {
            var ghes = await _context.Ghes.FindAsync(id);

            _context.Entry(ghes).State = EntityState.Modified;
            ghes.TrangThai= request.TrangThai;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GhesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ghes);
        }

        // POST: api/Ghes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ghes>> PostGhes(Ghes ghes)
        {
            _context.Ghes.Add(ghes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGhes", new { id = ghes.Id }, ghes);
        }

        // DELETE: api/Ghes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ghes>> DeleteGhes(int id)
        {
            var ghes = await _context.Ghes.FindAsync(id);
            if (ghes == null)
            {
                return NotFound();
            }

            _context.Ghes.Remove(ghes);
            await _context.SaveChangesAsync();

            return ghes;
        }

        private bool GhesExists(int id)
        {
            return _context.Ghes.Any(e => e.Id == id);
        }
    }
}
