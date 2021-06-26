using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Momo
{
    public class MomoRequest
    {
        [JsonProperty("partnerCode")]
        public string PartnerCode { get; set; }

        [JsonProperty("accessKey")]
        public string AccessKey { get; set; }

        [JsonProperty("orderInfo")]
        public string OrderInfo { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("extraData")]
        public string ExtraData { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("requestType")]
        public string RequestType { get; set; }
    }
}
