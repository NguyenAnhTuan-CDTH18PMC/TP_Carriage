using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class LichTrinhs
    {
        public int Id { get; set; }
        public decimal GiaChuyenDi { get; set; }
        public int KhoangCach { get; set; }
        public int ThoiGianUocTinh { get; set; }
        public int TrangThai { get; set; }

        public int DiaDiemId { get; set; }
        public virtual DiaDiems DiaDiems { get; set; }

        public virtual ICollection<ChuyenXes> ChuyenXes { get; set; }
    }
}