using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class DiaDiems
    {
        public DiaDiems()
        {
            LichTrinhs = new HashSet<LichTrinhs>();
        }

        public int Id { get; set; }
        public string TenDiemDi { get; set; }
        public string HinhAnh { get; set; }
        public string DiaChi { get; set; }
        public string Mota { get; set; }
        public int TrangThai { get; set; }

        public virtual ICollection<LichTrinhs> LichTrinhs { get; set; }
    }
}
