using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Ghes
    {
        public Ghes()
        {
            ChiTietVes = new HashSet<ChiTietVes>();
        }

        public int Id { get; set; }
        public int SoHang { get; set; }
        public int SoCot { get; set; }
        public string TrangThai { get; set; }


        public virtual LoaiGhes LoaiGhe { get; set; }
        public virtual Xes Xe { get; set; }
        public virtual ICollection<ChiTietVes> ChiTietVes { get; set; }
    }
}
