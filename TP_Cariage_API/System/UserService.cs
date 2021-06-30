using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP_Cariage_API.Models;

namespace TP_Cariage_API.System
{
    public class UserService : IUserService
    {
        private readonly UserManager<Accounts> _userManager;
        private readonly SignInManager<Accounts> _signInManager;
        //private readonly RoleManager<Accounts> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<Accounts> userManager,SignInManager<Accounts> signInManager,/*RoleManager<Accounts> roleManager,*/ IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user =await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return null;
            var result =await _signInManager.PasswordSignInAsync(user, request.Password, request.LoginRenember, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var role = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Name,user.TenKh),
               new Claim("uid",user.Id),
               new Claim(ClaimTypes.Role,string.Join(":",role))
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token=new JwtSecurityToken(
                issuer: _config["Tokens:Issuer"],
                audience: _config["Tokens:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials:creds);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new Accounts()
            {
                Email = request.Email,
                TenKh = request.TenKh,
                Cmnd = request.Cmnd,
                UserName = request.Email,
                DiaChi = request.DiaChi   ,
                GioiTinh=request.GioiTinh
                
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
