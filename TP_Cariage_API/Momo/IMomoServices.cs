using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Momo
{
    public interface IMomoServices
    {
        MomoResponse PaymentRequeset(MomoRequest request);
    }
   
}
