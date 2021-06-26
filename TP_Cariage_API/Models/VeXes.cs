using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class VeXes
    {
        public VeXes()
        {
            ChiTietVes = new HashSet<ChiTietVes>();
        }

        public int Id { get; set; }
        public int TrangThai { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual ChuyenXes ChuyenXe { get; set; }
        public virtual ICollection<ChiTietVes> ChiTietVes { get; set; }
    }
}
