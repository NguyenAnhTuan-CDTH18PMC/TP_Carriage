using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.System
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string newPassword { get; set; }
    }
}
