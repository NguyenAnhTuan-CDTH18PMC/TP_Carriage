using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class LoaiXes
    {
        public LoaiXes()
        {
            Xes = new HashSet<Xes>();
        }

        public int Id { get; set; }
        public string TenLoai { get; set; }
        public string HinhAnh { get; set; }
        public int TrangThai { get; set; }

        public virtual ICollection<BangGias> BangGias { get; set; }
        public virtual ICollection<Xes> Xes { get; set; }
    }
}
