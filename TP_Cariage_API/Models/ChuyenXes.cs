using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class ChuyenXes
    {
        public ChuyenXes()
        {
            VeXes = new HashSet<VeXes>();
        }

        public int Id { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string GioKhoiHanh { get; set; }
        public string ThoiGianDen { get; set; }
        public int TrangThai { get; set; }

        public virtual LichTrinhs LichTrinh { get; set; }
        public virtual Xes Xe { get; set; }
        public virtual ICollection<VeXes> VeXes { get; set; }
    }
}
