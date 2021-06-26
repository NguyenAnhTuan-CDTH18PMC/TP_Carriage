using System;
using System.Collections.Generic;

namespace TP_Cariage_API.Models
{
    public partial class Messages
    {
        public int Id { get; set; }
        public string Descreption { get; set; }
        public bool IsSeen { get; set; }
        public bool IsReceved { get; set; }
        public bool IsDelete { get; set; }

        public virtual Messagegroups Messagegroup { get; set; }
    }
}
