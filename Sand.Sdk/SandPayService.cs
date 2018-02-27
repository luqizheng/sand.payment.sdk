using Microsoft.Extensions.Logging;
using Sand.Sdk.CheckoutCounters;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sand.Sdk
{
    public enum AccessType
    {
        Normal = 1,
        Platform = 2
    }

    public class SandPayService
    {
        public SandPayService(string host)
        {
            this.host = host;
        }
        private readonly string platformId;
        private readonly string host;

        public ResponsePayment PayByGateway(MerchantInfo info, RequestPayOrderBody body, bool isMobile = false)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            body.Valid();

            var header = CreateHeader(info, "sandpay.trade.pay");
            header.ChannelType = isMobile ? "08" : "07";

            header.ProductId = PayMode.GetProduct(body);


            RequestPayOrder payment = new RequestPayOrder();


            payment.Header = header;
            payment.Body = body;

            HttpRequestHelper helper = new HttpRequestHelper(host);
            return helper.Post<ResponsePayment, RequestPayOrder>("order/pay", info, payment);
        }

        public ResponseQueryPayment Query(MerchantInfo info, RequestQueryBody body, bool isMobile = false)
        {
            string method = "sandpay.trade.query";
            var header = CreateHeader(info, method);
            header.ChannelType = isMobile ? "08" : "07";
            var payment = new RequestQueryPayment();


            payment.Header = header;
            payment.Body = body;

            HttpRequestHelper helper = new HttpRequestHelper(host);
            return helper.Post<ResponseQueryPayment, RequestQueryPayment>("order/query", info, payment);
        }

        public ResponseRefundPayment Refund(MerchantInfo info, RequestRefundBody body, bool isMobile = false)
        {
            string method = "sandpay.trade.refund";
            var header = CreateHeader(info, method);
            header.ChannelType = isMobile ? "08" : "07";
            var payment = new RequestRefundPayment();


            payment.Header = header;
            payment.Body = body;

            HttpRequestHelper helper = new HttpRequestHelper(host);
            return helper.Post<ResponseRefundPayment, RequestRefundPayment>("order/refund", info, payment);
        }

        public IDictionary<string, string> PayByCounter(MerchantInfo info, CheckoutCounter orderInfo, out string postUrl)
        {
            postUrl = host + "/order/gwayOrderPay";
            var dict = new Dictionary<string, string>();

            dict.Add("orderCode", orderInfo.orderCode);
            dict.Add("totalAmount", orderInfo.totalAmount.ToString().PadLeft(12, '0'));
            dict.Add("subject", orderInfo.subject);
            dict.Add("body", orderInfo.body);
            dict.Add("txnTimeOut", orderInfo.txnTimeOut);
            dict.Add("payMode", orderInfo.payMode);
            dict.Add("payExtra", orderInfo.payExtra);
            dict.Add("clientIp", orderInfo.clientIp);
            dict.Add("notifyUrl", orderInfo.notifyUrl);
            dict.Add("frontUrl", orderInfo.frontUrl);
            dict.Add("storeId", orderInfo.storeId);
            dict.Add("terminalId", orderInfo.terminalId);
            dict.Add("operatorId", orderInfo.operatorId);
            dict.Add("clearCycle", orderInfo.clearCycle);
            dict.Add("riskRateInfo", orderInfo.riskRateInfo);
            dict.Add("bizExtendParams", orderInfo.bizExtendParams);
            dict.Add("merchExtendParams", orderInfo.merchExtendParams);
            dict.Add("extend", orderInfo.extend);
            return dict;
        }
        private RequestHeader CreateHeader(MerchantInfo info, string method)
        {
            RequestHeader header = new RequestHeader()
            {
                Method = method,
                Mid = info.MerchantId,
                AccessType = Convert.ToInt32(info.AccessType).ToString(),
            };
            return header;
        }


    }
}
