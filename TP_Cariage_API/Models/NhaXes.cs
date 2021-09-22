using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class NhaXes
    {
        public NhaXes()
        {
            Chats = new HashSet<Comment>();
            NhanXets = new HashSet<NhanXets>();
            Xes = new HashSet<Xes>();
        }

        public int Id { get; set; }
        public string TenNhaXe { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuongXe { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        public int BenXeId { get; set; }
        public virtual BenXes BenXes { get; set; }

        public string AccountsEmail { get; set; }
        public virtual Accounts Accounts { get; set; }

        public virtual ICollection<Comment> Chats { get; set; }
        public virtual ICollection<NhanXets> NhanXets { get; set; }
        public virtual ICollection<Xes> Xes { get; set; }
        public virtual ICollection<BangGias> BangGias { get; set; }
    }
}
