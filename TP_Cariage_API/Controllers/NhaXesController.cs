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
    public class NhaXesController : ControllerBase
    {
        private readonly TPCarriageContext _context;
        private readonly UserManager<Accounts> _userManager;
        public NhaXesController(TPCarriageContext context, UserManager<Accounts> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/NhaXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaXes>>> GetNhaXes()
        {
            return await _context.NhaXes.ToListAsync();
        }

        // GET: api/NhaXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaXes>> GetNhaXes(int id)
        {
            var nhaXes = await _context.NhaXes.FindAsync(id);
            nhaXes.BenXes = await _context.BenXes.FindAsync(nhaXes.BenXeId);
            nhaXes.Accounts = await _userManager.FindByEmailAsync(nhaXes.AccountsEmail);
            if (nhaXes == null)
            {
                return NotFound();
            }

            return nhaXes;
        }

        [HttpGet("Email/{email}")]
        public async Task<ActionResult<IEnumerable<NhaXes>>> GetNhaXes(string email)
        {
            List<NhaXes> result = new List<NhaXes>();
            List<NhaXes> listNhaXe = await _context.NhaXes.ToListAsync();
            if (listNhaXe == null)
            {
                return NotFound();
            }
            foreach (NhaXes nhaXes in listNhaXe)
            {
                if (nhaXes.AccountsEmail==email)
                {
                    nhaXes.BenXes = await _context.BenXes.FindAsync(nhaXes.BenXeId);
                    nhaXes.Accounts =await _userManager.FindByEmailAsync(nhaXes.AccountsEmail);
                    result.Add(nhaXes);
                }
            }
            return result;
        }
        // PUT: api/NhaXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutNhaXes(int id, NhaXes nhaXes)
        {
            if (id != nhaXes.Id)
            {
                return BadRequest();
            }

            _context.Entry(nhaXes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaXesExists(id))
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

        // POST: api/NhaXes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NhaXes>> PostNhaXes(NhaXes nhaXes)
        {
            _context.NhaXes.Add(nhaXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhaXes", new { id = nhaXes.Id }, nhaXes);
        }

        // DELETE: api/NhaXes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<NhaXes>> DeleteNhaXes(int id)
        {
            var nhaXes = await _context.NhaXes.FindAsync(id);
            if (nhaXes == null)
            {
                return NotFound();
            }

            _context.NhaXes.Remove(nhaXes);
            await _context.SaveChangesAsync();

            return nhaXes;
        }

        private bool NhaXesExists(int id)
        {
            return _context.NhaXes.Any(e => e.Id == id);
        }
    }
}
