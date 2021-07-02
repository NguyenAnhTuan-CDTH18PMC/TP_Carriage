using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public ChiTietVesController(TPCarriageContext context, IMomoServices momoServices)
        {
            _context = context;
            _MomoServices = momoServices;
        }

        // GET: api/ChiTietVes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietVes>>> GetChiTietVes()
        {
            return await _context.ChiTietVes.ToListAsync();
        }

        // GET: api/ChiTietVes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietVes>> GetChiTietVes(int id)
        {
            var chiTietVes = await _context.ChiTietVes.FindAsync(id);
            chiTietVes.Ghe = await _context.Ghes.FindAsync(chiTietVes.GheId);
            chiTietVes.VeXe = await _context.VeXes.FindAsync(chiTietVes.VeXeId);
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
        public async Task<ActionResult<ChiTietVes>> PostChiTietVes(ChiTietVes chiTietVes)
        {
            _context.ChiTietVes.Add(chiTietVes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietVes", new { id = chiTietVes.Id }, chiTietVes);
        }

        // DELETE: api/ChiTietVes/5
        [HttpDelete("{id}")]
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
