using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Models
{
    public class TienIchs
    {
        public int Id { get; set; }
        public string TenTienIch { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<TienIchCuaXes> TienIchCuaXes { get; set; }
    }
}
