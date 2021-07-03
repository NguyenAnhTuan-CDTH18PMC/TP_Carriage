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
    public class ChuyenXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public ChuyenXesController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/ChuyenXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuyenXes>>> GetChuyenXes()
        {
            List<ChuyenXes> listChuyenXe = await _context.ChuyenXes.ToListAsync();
            if (listChuyenXe == null)
            {
                return NotFound();
            }
            foreach (ChuyenXes chuyenXes in listChuyenXe)
            {
                chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                chuyenXes.LichTrinhs.DiaDiems = await _context.DiemDens.FindAsync(chuyenXes.LichTrinhs.DiaDiemId);
                chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
            }
            return listChuyenXe;
        }

        [HttpGet("{NhaXes/id}")]
        public async Task<ActionResult<IEnumerable<ChuyenXes>>> GetChuyenXesNhaXes(int id)
        {
            List<ChuyenXes> result=new List<ChuyenXes>();
            List<ChuyenXes> listChuyenXe = await _context.ChuyenXes.ToListAsync();
            if (listChuyenXe == null)
            {
                return NotFound();
            }
            foreach (ChuyenXes chuyenXes in listChuyenXe)
            {
                if (chuyenXes.Xes.NhaXeId == id)
                {
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiaDiems = await _context.DiemDens.FindAsync(chuyenXes.LichTrinhs.DiaDiemId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    result.Add(chuyenXes);
                }
            }
            return result;
        }

        // GET: api/ChuyenXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuyenXes>> GetChuyenXes(int id)
        {
            var chuyenXes = await _context.ChuyenXes.FindAsync(id);
            chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
            chuyenXes.LichTrinhs.DiaDiems = await _context.DiemDens.FindAsync(chuyenXes.LichTrinhs.DiaDiemId);
            chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
            chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
            chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
            if (chuyenXes == null)
            {
                return NotFound();
            }

            return chuyenXes;
        }

        // PUT: api/ChuyenXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuyenXes(int id, ChuyenXes chuyenXes)
        {
            if (id != chuyenXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(chuyenXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuyenXesExists(id))
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

        // POST: api/ChuyenXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChuyenXes>> PostChuyenXes(ChuyenXes chuyenXes)
        {
            _context.ChuyenXes.Add(chuyenXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChuyenXes", new { id = chuyenXes.Id }, chuyenXes);
        }

        // DELETE: api/ChuyenXes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChuyenXes>> DeleteChuyenXes(int id)
        {
            var chuyenXes = await _context.ChuyenXes.FindAsync(id);
            if (chuyenXes == null)
            {
                return NotFound();
            }

            _context.ChuyenXes.Remove(chuyenXes);
            await _context.SaveChangesAsync();

            return chuyenXes;
        }

        private bool ChuyenXesExists(int id)
        {
            return _context.ChuyenXes.Any(e => e.Id == id);
        }
    }
}
