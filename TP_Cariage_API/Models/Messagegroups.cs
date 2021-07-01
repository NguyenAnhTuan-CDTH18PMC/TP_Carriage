using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Messagegroups
    {

        public int Id { get; set; }
        public string TenGroup { get; set; }
        public bool IsSeen { get; set; }
        public bool IsReceved { get; set; }
        public bool IsDelete { get; set; }

    }
}
