using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Cariage_API.Data;
using TP_Cariage_API.DTOs;
using TP_Cariage_API.Models;
using TP_Cariage_API.System;

namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TPCarriageContext _context;
        private readonly IUserService _userService;
        private readonly UserManager<Accounts> _userManager;
        public AccountsController(TPCarriageContext context, IUserService userService, UserManager<Accounts> userManager)
        {
            _userService = userService;
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Accounts
        
        [HttpGet("GetAllUsers")]  
        [Authorize]
        public async Task<IActionResult> GetAccounts()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var users = await _userManager.Users.ToListAsync();
            var temp = new List<Accounts>();
            foreach (Accounts user in users)
            {
                if (user.Quyen == 1)
                {
                    temp.Add(user);
                }
            }
                return Ok(temp);
        }

        // GET: api/Accounts/5
        [HttpGet("UserInfo")]
        [Authorize]
        public IActionResult GetAccountsByToken()
        {
            var email = string.Empty;
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                email = identity.FindFirst(ClaimTypes.Email).Value;
            }
            var user = _userManager.FindByEmailAsync(email);
            return Ok(user);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        [HttpPut("{email}")]
        [Authorize]
        public async Task<IActionResult> PutAccounts(string email, UserModel accounts)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    user.NamSinh = accounts.NamSinh;
                    user.Cmnd = accounts.Cmnd;
                    user.TenKh = accounts.TenKh;
                    user.DiaChi = accounts.DiaChi;
                    user.Password = accounts.Password;
                    user.AnhDaiDien = accounts.AnhDaiDien;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExistsAsync(email).Result)
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

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAccounts(UserModel request)
        {
            var userWithSameUserName = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameUserName != null)
            {
                return Ok("Account have already");
            }
            var user = new Accounts()
            {
                Email = request.Email,
                TenKh = request.TenKh,
                Cmnd = request.Cmnd,
                DiaChi = request.DiaChi,
                NamSinh = request.NamSinh,
                Quyen = request.Quyen,
                NgayTaoTk = request.NgayTaoTk,
                TrangThai = request.TrangThai,
                Password = request.Password


            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    //Add roles
                    await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{email}")]
        [Authorize]
        public async Task<ActionResult<Accounts>> DeleteAccounts(string email)
        {
            var accounts = await _userManager.FindByEmailAsync(email);
            if (accounts == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(accounts);

            return accounts;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authencate(request);          
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("email or password is incorrect");
            }
            if(string.Equals(resultToken, "Email chưa được xác thực"))
            {
                return Unauthorized("Email chưa được xác thực");
            }
            return Ok(new { token = resultToken });
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if ( !await AccountsExistsAsync(request.Email))
            {
                var result = await _userService.Register(request);
                if (!result)
                {
                    return BadRequest();
                }
                return Ok("Vui lòng kiểm tra email để xác nhận tài khoản");
            }
            else
            {
                return BadRequest("Email đã tồn tại");
            }
          
        }
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> FogetPassword([FromBody] ForgetPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await AccountsExistsAsync(request.Email))
            {
                var result = await _userService.ForgotPassword(request);
                if (!result)
                {
                    return BadRequest();
                }
                return Ok("Vui lòng kiểm tra email để thay đổi tài khoản");
            }
            else
            {
                return BadRequest("Vui lòng thử lại");
            }

        }
        [HttpPost("Reset-Password")]
        public async Task<ContentResult> ForgetPasswordEmail([FromBody]ResetPasswordRequest resetPasswordRequest)
        {
            return await _userService.ForgetPassword(resetPasswordRequest.Email, resetPasswordRequest.Token, resetPasswordRequest.newPassword);
        }
        [HttpGet("confirm-email")]
        public async Task<ContentResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string code)
        {
            return await _userService.ConfirmEmail(userId, code);
        }

       
        private async Task<bool> AccountsExistsAsync(string email)
        {
            var accounts = await _userManager.FindByEmailAsync(email);
            if (accounts == null)
            {
                return false;
            }

            return true;
        }


    }
}
