using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.DTOs
{
    public class UserModel
    {
        public string Password { get; set; }
        public string TenKh { get; set; }
        public string Cmnd { get; set; }
        public string Email { get; set; }
        public string AnhDaiDien { get; set; }
        public string DiaChi { get; set; }
        public DateTime NamSinh { get; set; }
        public int Quyen { get; set; }
        public DateTime NgayTaoTk { get; set; }
        public int TrangThai { get; set; }
    }
}
