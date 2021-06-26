using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class NhanXets
    {
        public int Id { get; set; }
        public string NoiDungNhanXet { get; set; }
        public DateTime NgayNhanXet { get; set; }
        public int TrangThai { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual NhaXes NhaXe { get; set; }
    }
}
