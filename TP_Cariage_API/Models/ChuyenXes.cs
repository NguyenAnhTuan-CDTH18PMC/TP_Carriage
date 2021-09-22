using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class ChuyenXes
    {
        public int Id { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string GioKhoiHanh { get; set; }
        public string ThoiGianDen { get; set; }
        public int TrangThai { get; set; }

        public int LichTrinhId { get; set; }
        public virtual LichTrinhs LichTrinhs { get; set; }
        public int XeId { get; set; }
        public virtual Xes Xes { get; set; }
        public virtual ICollection<VeXes> VeXes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
