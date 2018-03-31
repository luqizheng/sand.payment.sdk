using System;
using System.Collections.Generic;
using Sand.Sdk.CheckoutCounters;

namespace Sand.Sdk
{
    public enum AccessType
    {
        Normal = 1,
        Platform = 2
    }

    public class SandPayService
    {
        private readonly string host;
        private readonly string platformId;

        public SandPayService(string host)
        {
            this.host = host;
        }

        public ResponsePayment PayByGateway(MerchantInfo info, RequestPayOrderBody body, bool isMobile = false)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            if (body == null) throw new ArgumentNullException(nameof(body));

            body.Valid();

            var header = CreateHeader(info, "sandpay.trade.pay");
            header.ChannelType = isMobile ? "08" : "07";

            header.ProductId = PayMode.GetProduct(body);


            var payment = new RequestPayOrder();


            payment.Header = header;
            payment.Body = body;

            var helper = new HttpRequestHelper(host);
            return helper.Post<ResponsePayment, RequestPayOrder>("order/pay", info, payment);
        }

        public ResponseQueryPayment Query(MerchantInfo info, RequestQueryBody body, bool isMobile = false)
        {
            var method = "sandpay.trade.query";
            var header = CreateHeader(info, method);
            header.ChannelType = isMobile ? "08" : "07";
            var payment = new RequestQueryPayment();


            payment.Header = header;
            payment.Body = body;

            var helper = new HttpRequestHelper(host);
            return helper.Post<ResponseQueryPayment, RequestQueryPayment>("order/query", info, payment);
        }

        public ResponseRefundPayment Refund(MerchantInfo info, RequestRefundBody body, bool isMobile = false)
        {
           
            var header = CreateHeader(info, "sandpay.trade.refund");
            header.ChannelType = isMobile ? "08" : "07";
            var payment = new RequestRefundPayment();


            payment.Header = header;
            payment.Body = body;

            var helper = new HttpRequestHelper(host);
            return helper.Post<ResponseRefundPayment, RequestRefundPayment>("order/refund", info, payment);
        }

        /// <summary>
        ///     跳转方式获得数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderInfo"></param>
        /// <param name="postUrl"></param>
        /// <returns></returns>
        public IDictionary<string, string> PayByCounter(MerchantInfo info, CheckoutCounter orderInfo,
            out string postUrl)
        {
            postUrl = host + "/order/gwayOrderPay";
            var dict = new Dictionary<string, string>
            {
                {"orderCode", orderInfo.orderCode},
                {"totalAmount", orderInfo.totalAmount.ToString().PadLeft(12, '0')},
                {"subject", orderInfo.subject},
                {"body", orderInfo.body}
            };

            if (string.IsNullOrEmpty(orderInfo.txnTimeOut))
                dict.Add("txnTimeOut", orderInfo.txnTimeOut);
            dict.Add("payMode", orderInfo.payMode);
            if (string.IsNullOrEmpty(orderInfo.payExtra))
                dict.Add("payExtra", orderInfo.payExtra);
            dict.Add("clientIp", orderInfo.clientIp);
            dict.Add("notifyUrl", orderInfo.notifyUrl);
            dict.Add("frontUrl", orderInfo.frontUrl);
            if (string.IsNullOrEmpty(orderInfo.storeId))
                dict.Add("storeId", orderInfo.storeId);

            if (string.IsNullOrEmpty(orderInfo.terminalId))
                dict.Add("terminalId", orderInfo.terminalId);
            if (string.IsNullOrEmpty(orderInfo.operatorId))
                dict.Add("operatorId", orderInfo.operatorId);

            dict.Add("clearCycle", Convert.ToInt32(orderInfo.clearCycle).ToString());

            if (string.IsNullOrEmpty(orderInfo.riskRateInfo))
                dict.Add("riskRateInfo", orderInfo.riskRateInfo);


            if (string.IsNullOrEmpty(orderInfo.bizExtendParams))
                dict.Add("bizExtendParams", orderInfo.bizExtendParams);
            if (string.IsNullOrEmpty(orderInfo.merchExtendParams))
                dict.Add("merchExtendParams", orderInfo.merchExtendParams);
            if (string.IsNullOrEmpty(orderInfo.extend))
                dict.Add("extend", orderInfo.extend);
            return dict;
        }

        private RequestHeader CreateHeader(MerchantInfo info, string method)
        {
            var header = new RequestHeader
            {
                Method = method,
                Mid = info.MerchantId,
                AccessType = info.AccessType
            };
            return header;
        }
    }
}