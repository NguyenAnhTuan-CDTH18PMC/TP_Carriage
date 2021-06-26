using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class LoaiGhes
    {
        public LoaiGhes()
        {
            Ghes = new HashSet<Ghes>();
        }

        public int Id { get; set; }
        public decimal GiaGhe { get; set; }
        public string HinhAnh { get; set; }
        public int TrangThai { get; set; }

        public virtual ICollection<Ghes> Ghes { get; set; }
    }
}
