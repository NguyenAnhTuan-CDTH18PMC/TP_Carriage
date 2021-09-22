using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Accounts:IdentityUser
    {
        public string Password { get; set; }
        public string TenKh { get; set; }
        public string Cmnd { get; set; }
        public string AnhDaiDien { get; set; }
        public string DiaChi { get; set; }
        public DateTime NamSinh { get; set; }
        public int Quyen { get; set; }
        public DateTime NgayTaoTk { get; set; }
        public int GioiTinh { get; set; }
        public int TrangThai { get; set; }

        public virtual ICollection<NhanXets> NhanXets { get; set; }
        public virtual ICollection<NhaXes> NhaXes { get; set; }
        public virtual ICollection<VeXes> VeXes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
