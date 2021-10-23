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

namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;
        private readonly UserManager<Accounts> _userManager;
        public VeXesController(TPCarriageContext context, UserManager<Accounts> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/VeXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeXes>>> GetVeXes()
        {
            return await _context.VeXes.ToListAsync();
        }

        // GET: api/VeXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VeXes>> GetVeXes(int id)
        {
            var veXes = await _context.VeXes.FindAsync(id);
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
            if (veXes == null)
            {
                return NotFound();
            }

            return veXes;
        }


       /* [HttpGet("Accounts/{email}")]
        public async Task<IActionResult> GetCustomer(string email)
        {
            var vexe = await _context.VeXes.ToListAsync();
            var temp = new List<VeXes>();
            foreach(var item in vexe)
            {
                item.Accounts = await _userManager.FindByIdAsync(item.AccountId);
                if (item.Accounts.Email == email)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(item.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    item.ChuyenXes = chuyenXes;
                    temp.Add(item);
                }
            }
            if (temp == null)
            {
                return NotFound();
            }

            return Ok(temp);
        }*/

        [HttpGet("ChuyenXes/{id}")]
        public async Task<ActionResult<IEnumerable<VeXes>>> GetVeXesTheoChuyenXes(int id)   
        {
            List<VeXes> result = new List<VeXes>();
            List<VeXes> listVeXes = await _context.VeXes.ToListAsync();
            if (listVeXes == null)
            {
                return NotFound();
            }
            foreach (VeXes ves in listVeXes)
            {
                ves.Accounts = await _userManager.FindByIdAsync(ves.AccountId);
                if (ves.ChuyenXeId == id)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.ChuyenXes = chuyenXes;
                    ves.Accounts = await _userManager.FindByIdAsync(ves.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }
        [HttpGet("Accounts/{email}")]
        public async Task<ActionResult<IEnumerable<VeXes>>> GetVeXesTheoAccounts(string email)
        {
            List<VeXes> result = new List<VeXes>();
            List<VeXes> listVeXes = await _context.VeXes.ToListAsync();
            if (listVeXes == null)
            {
                return NotFound();
            }
            foreach (VeXes ves in listVeXes)
            {
                ves.Accounts = await _userManager.FindByIdAsync(ves.AccountId);
                if (ves.Accounts.Email == email)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.ChuyenXes = chuyenXes;
                    ves.Accounts = await _userManager.FindByIdAsync(ves.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }
        public async Task<List<VeXes>> GetVeXesChuyenXes(int id)
        {
            List<VeXes> result = new List<VeXes>();
            List<VeXes> listVeXes = await _context.VeXes.ToListAsync();
            if (listVeXes == null)
            {
                return null;
            }
            foreach (VeXes ves in listVeXes)
            {
                if (ves.ChuyenXeId==id)
                {
                    var chuyenXes = await _context.ChuyenXes.FindAsync(ves.ChuyenXeId);
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.NhaXes.BenXes = await _context.BenXes.FindAsync(chuyenXes.Xes.NhaXes.BenXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    ves.ChuyenXes = chuyenXes;
                    ves.Accounts = await _userManager.FindByIdAsync(ves.AccountId.ToString());
                    result.Add(ves);
                }
            }
            return result;
        }

        [HttpGet("NhaXes/{id}")]
        public async Task<ActionResult<IEnumerable<VeXes>>> GetVeXesNhaXes(int id)
        {

            List<ChuyenXes> result = new List<ChuyenXes>();
            List<ChuyenXes> listChuyenXe = await _context.ChuyenXes.ToListAsync();
            List<VeXes> listVeXes = new List<VeXes>();
            if (listChuyenXe == null)
            {
                return NotFound();
            }
            foreach (ChuyenXes chuyenXes in listChuyenXe)
            {
                var Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                var NhaXe = await _context.NhaXes.FindAsync(Xes.NhaXeId);
                if (NhaXe.Id == id)
                {
                    chuyenXes.LichTrinhs = await _context.LichTrinhs.FindAsync(chuyenXes.LichTrinhId);
                    chuyenXes.LichTrinhs.DiemDens = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDenId);
                    chuyenXes.LichTrinhs.DiemDis = await _context.DiaDiems.FindAsync(chuyenXes.LichTrinhs.DiemDiId);
                    chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
                    chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
                    chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
                    result.Add(chuyenXes);
                }
            }
            foreach (ChuyenXes chuyenXes in result)
            {
               var lstTam = GetVeXesChuyenXes(chuyenXes.Id);
                foreach(VeXes veXes in lstTam.Result)
                {
                    listVeXes.Add(veXes);
                }
            }
            return listVeXes;
        }
        // PUT: api/VeXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutVeXes(int id, VeXes veXes)
        {
            if (id != veXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(veXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeXesExists(id))
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

        // POST: api/VeXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VeXes>> PostVeXes(VeXes veXes)
        {
            _context.VeXes.Add(veXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeXes", new { id = veXes.Id }, veXes);
        }

        // DELETE: api/VeXes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<VeXes>> DeleteVeXes(int id)
        {
            var veXes = await _context.VeXes.FindAsync(id);
            if (veXes == null)
            {
                return NotFound();
            }

            _context.VeXes.Remove(veXes);
            await _context.SaveChangesAsync();

            return veXes;
        }

        private bool VeXesExists(int id)
        {
            return _context.VeXes.Any(e => e.Id == id);
        }
    }
}
