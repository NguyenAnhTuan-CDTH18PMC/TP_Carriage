using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Cariage_API.Data;
using TP_Cariage_API.DTOs;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BangGiasController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public BangGiasController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/BangGias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BangGias>>> GetBangGias()
        {
            List<BangGias> listBangGias = await _context.BangGias.ToListAsync();
            foreach (BangGias bangGias in listBangGias)
            {
                    LichTrinhs lichTrinhs = await _context.LichTrinhs.FindAsync(bangGias.LichTrinhsId);
                    lichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDenId);
                    lichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDiId);
                    bangGias.LichTrinhs = lichTrinhs;
               
                    bangGias.LoaiXes = await _context.LoaiXes.FindAsync(bangGias.LoaiXesId);

                    NhaXes nhaXes = await _context.NhaXes.FindAsync(bangGias.NhaXesId);
                    nhaXes.BenXes = await _context.BenXes.FindAsync(nhaXes.BenXeId);
                    bangGias.NhaXes = nhaXes;
                    bangGias.NhaXes.HinhAnh = "";
                bangGias.NhaXes.BangGias = null;
                bangGias.LichTrinhs.BangGias = null;
                bangGias.LoaiXes.HinhAnh = null;
            }
            return listBangGias;
        }

        [HttpGet("NhaXes/{id}")]
        public async Task<ActionResult<IEnumerable<BangGias>>> GetBangGiasTheoNhaXes(int id)
        {
            List<BangGias> result = new List<BangGias>();
            List<BangGias> listBangGias = await _context.BangGias.ToListAsync();
            if (listBangGias == null)
            {
                return NotFound();
            }
            foreach (BangGias bangGias in listBangGias)
            {
                if (bangGias.NhaXesId == id)
                {
                    LichTrinhs lichTrinhs = await _context.LichTrinhs.FindAsync(bangGias.LichTrinhsId);
                    lichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDenId);
                    lichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDiId);
                    bangGias.LichTrinhs = lichTrinhs;

                     bangGias.LoaiXes = await _context.LoaiXes.FindAsync(bangGias.LoaiXesId);

                    NhaXes nhaXes = await _context.NhaXes.FindAsync(bangGias.NhaXesId);
                    nhaXes.BenXes = await _context.BenXes.FindAsync(nhaXes.BenXeId);
                    bangGias.NhaXes = nhaXes;
                    bangGias.NhaXes.HinhAnh = "";
                    bangGias.NhaXes.BangGias = null;
                    bangGias.LichTrinhs.BangGias = null;
                    bangGias.LoaiXes.HinhAnh = "";
                    result.Add(bangGias);
                }
            }
            return result;
        }

        [HttpGet("SoSanh/{id}")]
        public async Task<ActionResult<IEnumerable<SoSanh>>> SoSanh(int id)
        {
            List<BangGias> result = new List<BangGias>();
            List<BangGias> listBangGias = await _context.BangGias.ToListAsync();
            List<SoSanh> test = new List<SoSanh>();
            if (listBangGias == null)
            {
                return NotFound();
            }
            foreach (BangGias bangGias in listBangGias)
            {
                if (bangGias.LichTrinhsId == id && bangGias.TrangThai==1)
                {
                    LichTrinhs lichTrinhs = await _context.LichTrinhs.FindAsync(bangGias.LichTrinhsId);
                    lichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDenId);
                    lichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDiId);
                    bangGias.LichTrinhs = lichTrinhs;

                    bangGias.LoaiXes = await _context.LoaiXes.FindAsync(bangGias.LoaiXesId);

                    NhaXes nhaXes = await _context.NhaXes.FindAsync(bangGias.NhaXesId);
                    nhaXes.BenXes = await _context.BenXes.FindAsync(nhaXes.BenXeId);
                    bangGias.NhaXes = nhaXes;
                    bangGias.NhaXes.HinhAnh = "";
                    bangGias.NhaXes.BangGias = null;
                    bangGias.LichTrinhs.BangGias = null;
                    bangGias.LoaiXes.HinhAnh = "";
                    result.Add(bangGias);
                    SoSanh temp = new SoSanh(bangGias.NhaXes.TenNhaXe,bangGias.LoaiXes.TenLoai,bangGias.GiaVe,bangGias.NhaXesId,bangGias.LoaiXesId,bangGias.Id);
                    test.Add(temp);
                }
            }
            return test;
        }
        // GET: api/BangGias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BangGias>> GetBangGias(int id)
        {
            var bangGias = await _context.BangGias.FindAsync(id);

            if (bangGias == null)
            {
                return NotFound();
            }
            LichTrinhs lichTrinhs = await _context.LichTrinhs.FindAsync(bangGias.LichTrinhsId);
            lichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDenId);
            lichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(lichTrinhs.DiemDiId);
            bangGias.LichTrinhs = lichTrinhs;

            bangGias.LoaiXes = await _context.LoaiXes.FindAsync(bangGias.NhaXesId);

            NhaXes nhaXes = await _context.NhaXes.FindAsync(bangGias.NhaXesId);
            nhaXes.BenXes = await _context.BenXes.FindAsync(nhaXes.BenXeId);
            bangGias.NhaXes = nhaXes;
            bangGias.NhaXes.HinhAnh = "";
            bangGias.NhaXes.BangGias = null;
            bangGias.LichTrinhs.BangGias = null;
            bangGias.LoaiXes.HinhAnh = "";
            return bangGias;
        }

        // PUT: api/BangGias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBangGias(int id, BangGias bangGias)
        {
            if (id != bangGias.Id)
            {
                return BadRequest();
            }

            _context.Entry(bangGias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BangGiasExists(id))
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

        // POST: api/BangGias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BangGias>> PostBangGias(BangGias bangGias)
        {
            List<BangGias> lstBangGia = await _context.BangGias.ToListAsync();
            foreach(BangGias test in lstBangGia)
            {
                if(test.NhaXesId==bangGias.NhaXesId && test.LoaiXesId==bangGias.LoaiXesId && test.LichTrinhsId == bangGias.LichTrinhsId)
                {
                    return BadRequest("Bảng giá này đã được tạo rồi!");
                }
            }
            _context.BangGias.Add(bangGias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBangGias", new { id = bangGias.Id }, bangGias);
        }

        // DELETE: api/BangGias/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BangGias>> DeleteBangGias(int id)
        {
            var bangGias = await _context.BangGias.FindAsync(id);
            if (bangGias == null)
            {
                return NotFound();
            }

            _context.BangGias.Remove(bangGias);
            await _context.SaveChangesAsync();

            return bangGias;
        }

        private bool BangGiasExists(int id)
        {
            return _context.BangGias.Any(e => e.Id == id);
        }
    }
}
