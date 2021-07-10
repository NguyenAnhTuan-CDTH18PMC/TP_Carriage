using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Cariage_API.Models
{
    public partial class DiaDiems
    {
        public int Id { get; set; }
        public string TenDiaDiem { get; set; }
        public string HinhAnh { get; set; }
        public string DiaChi { get; set; }
        public string Mota { get; set; }

        [NotMapped]
        public virtual ICollection<LichTrinhs> LichTrinhs{ get; set; }
    }
}
