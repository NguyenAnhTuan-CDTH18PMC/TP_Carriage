using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.System
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool LoginRenember { get; set; }
    }
}
