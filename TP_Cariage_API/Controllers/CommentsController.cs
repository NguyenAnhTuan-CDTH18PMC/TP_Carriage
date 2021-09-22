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
    public class CommentsController : ControllerBase
    {
        private readonly TPCarriageContext _context;
        private readonly UserManager<Accounts> _userManager;


        public CommentsController(TPCarriageContext context, UserManager<Accounts> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: api/News
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }
        // GET: api/Chats
        [HttpGet("ChuyenXes/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsTheoChuyenXe(int id)
        {
            List<Comment> listComments = await _context.Comments.ToListAsync();
            List<Comment> list = new List<Comment>();
            if (listComments == null)
            {
                return NotFound();
            }
            foreach (Comment comments in listComments)
            {
                if(comments.ChuyenXesId==id)
                {
                    comments.Accounts = await _userManager.FindByIdAsync(comments.AccountsId);
                    comments.Accounts.Comments = null;
                    comments.ChuyenXes = await _context.ChuyenXes.FindAsync(comments.ChuyenXesId);
                    comments.ChuyenXes.Comments = null;
                    list.Add(comments);
                }    
            }
            return list;
        }
        [HttpGet("ChuyenXes/{id}/Accounts/{accountid}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsHopLe(int id,string accountid)
        {
            List<Comment> listComments = await _context.Comments.ToListAsync();
            List<Comment> list = new List<Comment>();
            if (listComments == null)
            {
                return NotFound();
            }
            foreach (Comment comments in listComments)
            {
                if (comments.ChuyenXesId == id && comments.AccountsId==accountid)
                {
                    comments.Accounts = await _userManager.FindByIdAsync(comments.AccountsId);
                    comments.Accounts.Comments = null;
                    comments.ChuyenXes = await _context.ChuyenXes.FindAsync(comments.ChuyenXesId);
                    comments.ChuyenXes.Comments = null;
                    list.Add(comments);
                }
            }
            return list;
        }
        [HttpGet("DiemDanhGia/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetScoreChuyenXe(int id)
        {
            List<Comment> listComments = await _context.Comments.ToListAsync();
            float tongDiem = 0;
            float sl = 0;
            if (listComments == null)
            {
                return NotFound();
            }
            foreach (Comment comments in listComments)
            {
                if (comments.ChuyenXesId == id)
                {
                    sl++;
                    tongDiem += comments.DiemDanhGia;
                }
            }
            float TBB =tongDiem/sl;
            return Ok(TBB);
        }
        // PUT: api/Chats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutChats(int id, Comment chats)
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
        [Authorize]
        public async Task<ActionResult<Comment>> PostChats(Comment chats)
        {
            _context.Comments.Add(chats);
            chats.CreateAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComments", new { id = chats.Id }, chats);
        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Comment>> DeleteChats(int id)
        {
            var chats = await _context.Comments.FindAsync(id);
            if (chats == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(chats);
            await _context.SaveChangesAsync();

            return chats;
        }

        private bool ChatsExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
