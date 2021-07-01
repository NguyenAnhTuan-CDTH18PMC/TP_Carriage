using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Models
{
    public class TienIchCuaXes
    {
        public int Id { get; set; }

        public int XeId { get; set; }
        public virtual Xes Xes { get; set; }
        public int TienIchId { get; set; }
        public virtual TienIchs TienIchs { get; set; }
    }
}
