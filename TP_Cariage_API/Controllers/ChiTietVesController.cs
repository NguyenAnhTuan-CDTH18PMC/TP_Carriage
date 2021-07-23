using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Cariage_API.Data;
using TP_Cariage_API.Models;
using TP_Cariage_API.Momo;
namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietVesController : ControllerBase
    {
        private readonly TPCarriageContext _context;
        private readonly IMomoServices _MomoServices;
        private readonly UserManager<Accounts> _userManager;
        public ChiTietVesController(TPCarriageContext context, IMomoServices momoServices, UserManager<Accounts> userManager)
        {
            _context = context;
            _MomoServices = momoServices;
            _userManager = userManager;
        }

        // GET: api/ChiTietVes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> GetChiTietVes()
        {
            return await _context.ChiTietVes.ToListAsync();
        }
        [HttpGet("ChuyenXes/{id}")]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> GetVeXesTheoChuyenXes(int id)
        {
            List<ChiTietVes> result = new List<ChiTietVes>();
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            if (listChiTietVes == null)
            {
                return NotFound();
            }
            foreach (ChiTietVes ves in listChiTietVes)
            {
                if (ves.VeXes.ChuyenXeId == id)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.VeXes.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.VeXes.ChuyenXes = chuyenXes;
                    ves.VeXes.Accounts = await _userManager.FindByIdAsync(ves.VeXes.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }
        // GET: api/ChiTietVes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietVes>> GetChiTietVes(int id)
        {
            var chiTietVes = await _context.ChiTietVes.FindAsync(id);
            chiTietVes.Ghes = await _context.Ghes.FindAsync(chiTietVes.GheId);
            chiTietVes.Ghes.Xes = await _context.Xes.FindAsync(chiTietVes.Ghes.XeId);
            chiTietVes.Ghes.Xes.NhaXes = await _context.NhaXes.FindAsync(chiTietVes.Ghes.Xes.NhaXeId);
            chiTietVes.Ghes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chiTietVes.Ghes.Xes.NhaXes.BenXeId);
            chiTietVes.Ghes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chiTietVes.Ghes.Xes.LoaiXes);

            var veXes  = await _context.VeXes.FindAsync(chiTietVes.VeXeId);
            var chuyenXes = await _context.ChuyenXes.FindAsync(veXes.ChuyenXeId);
            chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
            chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
            chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
            chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
            chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
            chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
            chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
            veXes.ChuyenXes = chuyenXes;
            veXes.Accounts = await _userManager.FindByIdAsync(veXes.AccountId.ToString());
            chiTietVes.VeXes = veXes;
            if (chiTietVes == null)
            {
                return NotFound();
            }

            return chiTietVes;
        }

        // PUT: api/ChiTietVes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutChiTietVes(int id, ChiTietVes chiTietVes)
        {
            if (id != chiTietVes.Id)
            {
                return BadRequest();
            }

            _context.Entry(chiTietVes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietVesExists(id))
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

        // POST: api/ChiTietVes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ChiTietVes>> PostChiTietVes(ChiTietVes chiTietVes)
        {
            _context.ChiTietVes.Add(chiTietVes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietVes", new { id = chiTietVes.Id }, chiTietVes);
        }

        // DELETE: api/ChiTietVes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<ChiTietVes>> DeleteChiTietVes(int id)
        {
            var chiTietVes = await _context.ChiTietVes.FindAsync(id);
            if (chiTietVes == null)
            {
                return NotFound();
            }

            _context.ChiTietVes.Remove(chiTietVes);
            await _context.SaveChangesAsync();

            return chiTietVes;
        }

        private bool ChiTietVesExists(int id)
        {
            return _context.ChiTietVes.Any(e => e.Id == id);
        }


        [HttpPost("ThanhToan")]
        [Authorize]
        public async Task<IActionResult> Test(ChiTietVes chiTietVes)
        {
            var momoRequest = new MomoRequest();
            momoRequest.Amount = chiTietVes.GiaVe.ToString();
            momoRequest.OrderInfo = chiTietVes.GhiChu.ToString();
            var result = _MomoServices.PaymentRequeset(momoRequest);
            return Ok(result);
        }
    }
}
