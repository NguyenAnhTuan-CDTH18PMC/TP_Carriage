using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Momo
{
    public class MomoResponse
    {
        public string RequestId { get; set; }
        public int ErrorCode { get; set; }
        public string OrderId { get; set; }
        public string LocalMessage { get; set; }
        public string RequestType { get; set; }
        public string PayUrl { get; set; }
        public string Signature { get; set; }
    }
}
