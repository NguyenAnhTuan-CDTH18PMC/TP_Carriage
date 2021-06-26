using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class LichTrinhs
    {
        public LichTrinhs()
        {
            ChuyenXes = new HashSet<ChuyenXes>();
        }

        public int Id { get; set; }
        public decimal GiaChuyenDi { get; set; }
        public int KhoangCach { get; set; }
        public int ThoiGianUocTinh { get; set; }
        public int TrangThai { get; set; }

        public virtual DiaDiems DiaDiem { get; set; }
        public virtual ICollection<ChuyenXes> ChuyenXes { get; set; }
    }
}
