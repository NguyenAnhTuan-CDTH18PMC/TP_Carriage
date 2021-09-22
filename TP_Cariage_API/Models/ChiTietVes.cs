using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class ChiTietVes
    {
        public int Id { get; set; }
        public string GhiChu { get; set; }
        public decimal GiaVe { get; set; }
        public DateTime CreateAt { get; set; }

        public int GheId { get; set; }
        public virtual Ghes Ghes { get; set; }
        public int VeXeId { get; set; }
        public virtual VeXes VeXes { get; set; }
    }
}
