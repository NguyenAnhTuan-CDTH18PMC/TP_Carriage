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
    public class ChatsController : ControllerBase
    {
        private readonly TPCarriageContext _context;

        public ChatsController(TPCarriageContext context)
        {
            _context = context;
        }

        // GET: api/Chats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chats>>> GetChats()
        {
            return await _context.Chats.ToListAsync();
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chats>> GetChats(int id)
        {
            var chats = await _context.Chats.FindAsync(id);

            if (chats == null)
            {
                return NotFound();
            }

            return chats;
        }

        // PUT: api/Chats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChats(int id, Chats chats)
        {
            if (id != chats.Id)
            {
                return BadRequest();
            }

            _context.Entry(chats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatsExists(id))
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

        // POST: api/Chats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chats>> PostChats(Chats chats)
        {
            _context.Chats.Add(chats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChats", new { id = chats.Id }, chats);
        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chats>> DeleteChats(int id)
        {
            var chats = await _context.Chats.FindAsync(id);
            if (chats == null)
            {
                return NotFound();
            }

            _context.Chats.Remove(chats);
            await _context.SaveChangesAsync();

            return chats;
        }

        private bool ChatsExists(int id)
        {
            return _context.Chats.Any(e => e.Id == id);
        }
    }
}
