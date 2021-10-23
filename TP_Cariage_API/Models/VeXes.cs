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
        public DateTime ThoiGianHuy { get; set; }

        public string AccountId { get; set; }
        public virtual Accounts Accounts { get; set; }
        public int ChuyenXeId { get; set; }
        public virtual ChuyenXes ChuyenXes { get; set; }
        public virtual ICollection<ChiTietVes> ChiTietVes { get; set; }         
    }
}
