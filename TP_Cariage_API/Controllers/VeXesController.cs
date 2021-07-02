﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            chuyenXes.LichTrinhs.DiaDiems = await _context.DiemDens.FindAsync(chuyenXes.LichTrinhs.DiaDiemId);
            chuyenXes.Xes = await _context.Xes.FindAsync(chuyenXes.XeId);
            chuyenXes.Xes.NhaXes = await _context.NhaXes.FindAsync(chuyenXes.Xes.NhaXeId);
            chuyenXes.Xes.LoaiXes = await _context.LoaiXes.FindAsync(chuyenXes.Xes.LoaiXeId);
            veXes.ChuyenXes = chuyenXes;
            veXes.Accounts = await _userManager.FindByIdAsync(veXes.AccountId.ToString());
            if (veXes == null)
            {
                return NotFound();
            }

            return veXes;
        }

        // PUT: api/VeXes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
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
        public async Task<ActionResult<VeXes>> PostVeXes(VeXes veXes)
        {
            _context.VeXes.Add(veXes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeXes", new { id = veXes.Id }, veXes);
        }

        // DELETE: api/VeXes/5
        [HttpDelete("{id}")]
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
