using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class BenXes
    {
        public BenXes()
        {
            NhaXes = new HashSet<NhaXes>();
        }

        public int Id { get; set; }
        public string TenBenXe { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string HinhAnh { get; set; }
        public int TrangThai { get; set; }

        public virtual ICollection<NhaXes> NhaXes { get; set; }
    }
}
