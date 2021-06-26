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
    public class MessagegroupsController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public MessagegroupsController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/Messagegroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messagegroups>>> GetMessagegroups()
        {
            return await _context.Messagegroups.ToListAsync();
        }

        // GET: api/Messagegroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Messagegroups>> GetMessagegroups(int id)
        {
            var messagegroups = await _context.Messagegroups.FindAsync(id);

            if (messagegroups == null)
            {
                return NotFound();
            }

            return messagegroups;
        }

        // PUT: api/Messagegroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessagegroups(int id, Messagegroups messagegroups)
        {
            if (id != messagegroups.Id)
            {
                return BadRequest();
            }

            _context.Entry(messagegroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagegroupsExists(id))
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

        // POST: api/Messagegroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Messagegroups>> PostMessagegroups(Messagegroups messagegroups)
        {
            _context.Messagegroups.Add(messagegroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessagegroups", new { id = messagegroups.Id }, messagegroups);
        }

        // DELETE: api/Messagegroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Messagegroups>> DeleteMessagegroups(int id)
        {
            var messagegroups = await _context.Messagegroups.FindAsync(id);
            if (messagegroups == null)
            {
                return NotFound();
            }

            _context.Messagegroups.Remove(messagegroups);
            await _context.SaveChangesAsync();

            return messagegroups;
        }

        private bool MessagegroupsExists(int id)
        {
            return _context.Messagegroups.Any(e => e.Id == id);
        }
    }
}
