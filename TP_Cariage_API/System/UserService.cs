using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP_Cariage_API.Models;
using TP_Cariage_API.SendMail;

namespace TP_Cariage_API.System
{
    public class UserService : IUserService
    {
        private readonly UserManager<Accounts> _userManager;
        private readonly SignInManager<Accounts> _signInManager;
        //private readonly RoleManager<Accounts> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<Accounts> userManager, SignInManager<Accounts> signInManager,/*RoleManager<Accounts> roleManager,*/ IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user.EmailConfirmed)
            {
                if (user == null) return null;
                var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.LoginRenember, true);
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

                var token = new JwtSecurityToken(
                    issuer: _config["Tokens:Issuer"],
                    audience: _config["Tokens:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: creds);


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return "Email chưa được xác thực";
            }
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new Accounts()
            {
                Email = request.Email,
                TenKh = request.TenKh,
                Cmnd = request.Cmnd,
                UserName = request.Email,
                DiaChi = request.DiaChi,
                GioiTinh = request.GioiTinh

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            var u = user;
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                var verify = await SendVerificationEmail(user, "http://www.tpcarriage.somee.com");
                var sendEmail = await SendMail(new EmailRequest
                {
                    To = request.Email,
                    Subject = "Đây là email xác thực tài khoản từ TP_Carriage",
                    Body = "Hãy nhấp vào link sau đây để xác thực tài khoản : " + verify

                });;
                return true;
            }
            return false;
        }

        public Task<bool> SendMail(EmailRequest emailRequest)
        {
            try
            {
                string subject = emailRequest.Subject;
                string body = emailRequest.Body;
                string to = emailRequest.To;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("TP.Carriage.CaoThang@gmail.com");
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.UseDefaultCredentials = true;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("TP.Carriage.CaoThang@gmail.com", "AnhTuan0403");
                smtp.Send(mailMessage);
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromResult(false);
            }
        }
        public async Task<ContentResult> ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return new ContentResult
                {
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = "<html><body>"
                    + "<meta charset =utf-8>"
                    + "<h1 style=color:#25D366><center><img width=20 height=20 src=https://cachbothuocla.vn/wp-content/uploads/2019/03/tick-xanh.png>" + "Bạn đã xác thực thành công</center></h1>"
                    + "<span><center><strong>" + user.TenKh.ToString() + " đã trở thành thành viên của TP_Carriage</strong></center></span>"
                    + "<span><center><strong>TP_Carriage xin cảm ơn</strong></center></span>"
                    + "<center><img height=500 width=800 src=https://anhdep123.com/wp-content/uploads/2020/05/h%C3%ACnh-%E1%BA%A3nh-c%E1%BA%A3m-%C6%A1n.jpg>" + "</center>"
                + "</body></html>"
                };
            }
            else
            {
                return new ContentResult
                {
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = "<html><body>"
                    + "<meta charset =utf-8>"
                    + "<h1 style=color:#25D366><center><img width=20 height=20 src=https://icon2.cleanpng.com/20180529/zic/kisspng-desktop-wallpaper-computer-icons-clip-art-red-x-5b0dc6f9aaa3e0.188420681527629561699.jpg>" + "Bạn đã xác thực thất bại</center></h1>"
                    + "<span><center><strong>" + user.TenKh.ToString() + "hãy thử lại nhé</strong></center></span>"
                    + "<center><img height=500 width=800 src=https://anhdep123.com/wp-content/uploads/2020/05/h%C3%ACnh-%E1%BA%A3nh-c%E1%BA%A3m-%C6%A1n.jpg>" + "</center>"
                + "</body></html>"
                };
            }
        }
        private async Task<string> SendVerificationEmail(Accounts user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/Accounts/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            return verificationUri;
        }

        private async Task<string> SendForgetPasswordEmail(Accounts user, string origin)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var route = "reset-password/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = _enpointUri.ToString() + user.Email + "/" + code;
            return verificationUri;
        }
        public async Task<ContentResult> ForgetPassword(string email, string code,string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);           
            var result = await _userManager.ResetPasswordAsync(user, code, newPassword);
            if (result.Succeeded)
            {
                return new ContentResult
                {
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = "<html><body>"
                    + "<meta charset =utf-8>"
                    + "<h1 style=color:#25D366><center><img width=20 height=20 src=https://cachbothuocla.vn/wp-content/uploads/2019/03/tick-xanh.png>" + "Bạn đã thay đổi mật khẩu thành công</center></h1>"  + "<span><center><strong>TP_Carriage xin cảm ơn</strong></center></span>"
                    + "<center><img height=500 width=800 src=https://anhdep123.com/wp-content/uploads/2020/05/h%C3%ACnh-%E1%BA%A3nh-c%E1%BA%A3m-%C6%A1n.jpg>" + "</center>"
                + "</body></html>"
                };
            }
            else
            {
                return new ContentResult
                {
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = "<html><body>"
                    + "<meta charset =utf-8>"
                    + "<h1 style=color:#25D366><center><img width=20 height=20 src=https://icon2.cleanpng.com/20180529/zic/kisspng-desktop-wallpaper-computer-icons-clip-art-red-x-5b0dc6f9aaa3e0.188420681527629561699.jpg>" + "Bạn đã thay đổi mật khẩu thất bại</center></h1>"
                    + "<span><center><strong>" + user.TenKh.ToString() + "hãy thử lại nhé</strong></center></span>"
                    + "<center><img height=500 width=800 src=https://anhdep123.com/wp-content/uploads/2020/05/h%C3%ACnh-%E1%BA%A3nh-c%E1%BA%A3m-%C6%A1n.jpg>" + "</center>"
                + "</body></html>"
                };
            }
        }

        public async Task<bool> ForgotPassword(ForgetPasswordRequest request)
        {

            var result = await _userManager.FindByEmailAsync(request.Email);
            if (result!=null)
            {
                var verify = await SendForgetPasswordEmail(result, "https://localhost:3000");
                var sendEmail = await SendMail(new EmailRequest
                {
                    To = request.Email,
                    Subject = "Đây là email đổi mật khẩu tài khoản từ TP_Carriage",
                    Body = "Hãy nhấp vào link sau đây để đổi mật khẩu tài khoản : " + verify

                }); ;
                return true;
            }
            return false;
        }

     
    }
}
