using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Cariage_API.SendMail;

namespace TP_Cariage_API.System
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
         Task<bool> SendMail(EmailRequest emailRequest);
         Task<bool> ForgotPassword(ForgetPasswordRequest request);
        Task<ContentResult> ConfirmEmail(string userId, string code);
        Task<ContentResult> ForgetPassword(string email,string token, string newPassword);
    }
}
