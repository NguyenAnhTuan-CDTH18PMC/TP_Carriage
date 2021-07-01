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

        public int AccountId { get; set; }
        public virtual Accounts Accounts { get; set; }
        public int NhaXeId { get; set; }
        public virtual NhaXes NhaXes { get; set; }
    }
}
