using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Cariage_API.Momo
{
    public class MoMoServices : IMomoServices
    {
        public MomoResponse PaymentRequeset(MomoRequest request)
        {
            try
            {
                request.RequestId = Guid.NewGuid().ToString();
                request.AccessKey = "iklNUQQj0lVz7tBF";
                request.PartnerCode = "MOMOVYOH20210621";
                request.NotifyUrl = "https://momo.vn/notify";
                request.ReturnUrl = "https://momo.vn/return";
                request.RequestType = "captureMoMoWallet";
                request.OrderId= Guid.NewGuid().ToString();
                request.ExtraData = "";

                string rawHash = "partnerCode=" +
                request.PartnerCode + "&accessKey=" +
                request.AccessKey + "&requestId=" +
                request.RequestId + "&amount=" +
                request.Amount + "&orderId=" +
                request.OrderId + "&orderInfo=" +
                request.OrderInfo + "&returnUrl=" +
                request.ReturnUrl + "&notifyUrl=" +
                request.NotifyUrl + "&extraData=" +
                request.ExtraData;

                MomoSecurity crypto = new MomoSecurity();
                request.Signature = crypto.signSHA256(rawHash, "z2UtRK2xXH0pknRbxGj9pK4MX4rqleVo");
                var pre = JsonConvert.SerializeObject(request);
                string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
                var result = JsonConvert.DeserializeObject<MomoResponse>(PaymentRequest.sendPaymentRequest(endpoint,pre));
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    
}
