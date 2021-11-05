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
using TP_Cariage_API.DTOs;
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
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            if (listChiTietVes == null)
            {
                return NotFound();
            }
            foreach (ChiTietVes ves in listChiTietVes)
            {
                ves.VeXes = await _context.VeXes.FindAsync(ves.VeXeId);
                var chuyenXes = await _context.ChuyenXes.FindAsync(ves.VeXes.ChuyenXeId);
                chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                chuyenXes.Xes.HinhAnh = "";
                chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                chuyenXes.Xes.NhaXes.HinhAnh = "";
                chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                ves.Ghes = await _context.Ghes.FindAsync(ves.GheId);
                ves.Ghes.Xes = await _context.Xes.FindAsync(ves.Ghes.XeId);
                ves.VeXes.ChuyenXes = chuyenXes;
                ves.VeXes.Accounts = await _userManager.FindByIdAsync(ves.VeXes.AccountId.ToString());
            }
            return listChiTietVes;
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
                ves.VeXes = await _context.VeXes.FindAsync(ves.VeXeId);
                if (ves.VeXes.ChuyenXeId == id)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.VeXes.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.HinhAnh = "";
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.HinhAnh = "";
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);           
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.Ghes = await _context.Ghes.FindAsync(ves.GheId);
                    ves.Ghes.Xes = await _context.Xes.FindAsync(ves.Ghes.XeId);
                    ves.VeXes.ChuyenXes = chuyenXes;
                    ves.VeXes.Accounts = await _userManager.FindByIdAsync(ves.VeXes.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }

        [HttpGet("Accounts/{email}")]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> GetVeXesTheoAccounts(string email)
        {
            List<ChiTietVes> result = new List<ChiTietVes>();
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            if (listChiTietVes == null)
            {
                return NotFound();
            }
            foreach (ChiTietVes ves in listChiTietVes)
            {
                ves.VeXes = await _context.VeXes.FindAsync(ves.VeXeId);
                if (ves.VeXes.AccountId == email)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.VeXes.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.HinhAnh = "";
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.HinhAnh = "";
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.Ghes = await _context.Ghes.FindAsync(ves.GheId);
                    ves.Ghes.Xes = await _context.Xes.FindAsync(ves.Ghes.XeId);
                    ves.VeXes.ChuyenXes = chuyenXes;
                    ves.VeXes.Accounts = await _userManager.FindByIdAsync(ves.VeXes.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }
        [HttpGet("VeXes/{id}")]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> GetVeXesTheoVeXes(int id)
        {
            List<ChiTietVes> result = new List<ChiTietVes>();
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            if (listChiTietVes == null)
            {
                return NotFound();
            }
            foreach (ChiTietVes ves in listChiTietVes)
            {
                ves.VeXes = await _context.VeXes.FindAsync(ves.VeXeId);
                if (ves.VeXeId == id)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.VeXes.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.Ghes = await _context.Ghes.FindAsync(ves.GheId);
                    ves.Ghes.Xes = await _context.Xes.FindAsync(ves.Ghes.XeId);
                    ves.VeXes.ChuyenXes = chuyenXes;
                    ves.VeXes.Accounts = await _userManager.FindByIdAsync(ves.VeXes.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }

        [HttpGet("Money")]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> LayGiaTienTheoThang([FromHeader]Money money)
        {           
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            decimal tongtien = 0;
            foreach(ChiTietVes ctVes in listChiTietVes)
            {
                if (ctVes.CreateAt.Month == money.Thang && ctVes.CreateAt.Year==money.Nam)
                {
                    ctVes.Ghes = await _context.Ghes.FindAsync(ctVes.GheId);
                    ctVes.Ghes.Xes= await _context.Xes.FindAsync(ctVes.Ghes.XeId);
                    ctVes.Ghes.Xes.NhaXes= await _context.NhaXes.FindAsync(ctVes.Ghes.Xes.NhaXeId);
                    ctVes.VeXes = await _context.VeXes.FindAsync(ctVes.VeXeId);
                    ctVes.VeXes.ChuyenXes = await _context.ChuyenXes.FindAsync(ctVes.VeXes.ChuyenXeId);
                    ctVes.VeXes.ChuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(ctVes.VeXes.ChuyenXes.LichTrinhId);
                    if (ctVes.Ghes.Xes.NhaXeId == money.NhaXe && ctVes.VeXes.ChuyenXes.LichTrinhs.Id==money.LichTrinh)
                    {
                        tongtien += ctVes.GiaVe;
                    }
                }
            }
            LichTrinhs test = await _context.LichTrinhs.FindAsync(money.LichTrinh);
            test.DiemDens = await _context.DiaDiems.FindAsync(test.DiemDenId);
            test.DiemDis = await _context.DiaDiems.FindAsync(test.DiemDiId);
            NhaXeMoney temp = new NhaXeMoney(test.DiemDis.TenDiaDiem+" - "+test.DiemDens.TenDiaDiem,tongtien);
            return Ok(temp);
        }

        [HttpGet("MoneyList")]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> LayListDoanhThu([FromHeader] MYMY data)
        {
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            List<Report> temp = new List<Report>();
            decimal tongtien = 0;
            if (data.Nam2 < data.Nam1)
            {
                return Content("Năm trước phải lớn hơn năm sau");
            }
            if (data.Nam1 == data.Nam2)
            {
                while (data.Thang1 <= data.Thang2)
                {
                    foreach (ChiTietVes ctVes in listChiTietVes)
                    {
                        if (ctVes.CreateAt.Month==data.Thang1 && ctVes.CreateAt.Year==data.Nam1)
                        {
                            ctVes.Ghes = await _context.Ghes.FindAsync(ctVes.GheId);
                            ctVes.Ghes.Xes = await _context.Xes.FindAsync(ctVes.Ghes.XeId);
                            ctVes.Ghes.Xes.NhaXes = await _context.NhaXes.FindAsync(ctVes.Ghes.Xes.NhaXeId);
                            if (ctVes.Ghes.Xes.NhaXeId == data.NhaXe)
                            {
                                tongtien += ctVes.GiaVe;
                            }
                        }
                    }
                    Report hic = new Report(data.Thang1, tongtien);
                    temp.Add(hic);
                    tongtien = 0;
                    data.Thang1++;
                }
            }
            if (data.Nam1 < data.Nam2)
            {
                while (data.Thang1 <= 12)
                {
                    foreach (ChiTietVes ctVes in listChiTietVes)
                    {
                        if (ctVes.CreateAt.Month == data.Thang1 && ctVes.CreateAt.Year == data.Nam1)
                        {
                            ctVes.Ghes = await _context.Ghes.FindAsync(ctVes.GheId);
                            ctVes.Ghes.Xes = await _context.Xes.FindAsync(ctVes.Ghes.XeId);
                            ctVes.Ghes.Xes.NhaXes = await _context.NhaXes.FindAsync(ctVes.Ghes.Xes.NhaXeId);
                            if (ctVes.Ghes.Xes.NhaXeId == data.NhaXe)
                            {
                                tongtien += ctVes.GiaVe;
                            }
                        }
                    }
                    Report hic = new Report(data.Thang1, tongtien);
                    temp.Add(hic);
                    tongtien = 0;
                    data.Thang1++;
                }
                for(int i = 1; i <= data.Thang2; i++)
                {
                    foreach (ChiTietVes ctVes in listChiTietVes)
                    {
                        if (ctVes.CreateAt.Month == i && ctVes.CreateAt.Year == data.Nam2)
                        {
                            ctVes.Ghes = await _context.Ghes.FindAsync(ctVes.GheId);
                            ctVes.Ghes.Xes = await _context.Xes.FindAsync(ctVes.Ghes.XeId);
                            ctVes.Ghes.Xes.NhaXes = await _context.NhaXes.FindAsync(ctVes.Ghes.Xes.NhaXeId);
                            if (ctVes.Ghes.Xes.NhaXeId == data.NhaXe)
                            {
                                tongtien += ctVes.GiaVe;
                            }
                        }
                    }
                    Report hic = new Report(i, tongtien);
                    temp.Add(hic);
                    tongtien = 0;
                }
            }
            return Ok(temp);
        }
        [HttpGet("NhaXes/{id}")]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> GetVeXesTheoNhaXes(int id)
        {
            List<ChiTietVes> result = new List<ChiTietVes>();
            List<ChiTietVes> listChiTietVes = await _context.ChiTietVes.ToListAsync();
            if (listChiTietVes == null)
            {
                return NotFound();
            }
            foreach (ChiTietVes ves in listChiTietVes)
            {
                ves.VeXes = await _context.VeXes.FindAsync(ves.VeXeId);
                ves.Ghes = await _context.Ghes.FindAsync(ves.GheId);
                ves.Ghes.Xes = await _context.Xes.FindAsync(ves.Ghes.XeId);
                if (ves.Ghes.Xes.NhaXeId == id)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.VeXes.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.HinhAnh = "";
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.HinhAnh = "";
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
            chiTietVes.CreateAt = DateTime.Now;
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
