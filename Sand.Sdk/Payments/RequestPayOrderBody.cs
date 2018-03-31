using System;
using Newtonsoft.Json;

namespace Sand.Sdk
{
    /// <summary>
    /// 统一下单的数据提
    /// </summary>
    public class RequestPayOrderBody
    {
        public RequestPayOrderBody(int amt, SandCardPaymemnt payment)
            : this(amt)
        {
            PayMode = "sand_card";
            PayExtra = JsonConvert.SerializeObject(payment);
        }

        public RequestPayOrderBody(int amt, SandH5Payment payment)
            : this(amt)
        {
            PayMode = "sand_h5";
            PayExtra = JsonConvert.SerializeObject(payment);
        }

        public RequestPayOrderBody(int amt, SandWxH5 payment)
            : this(amt)
        {
            PayMode = "sand_wxh5";
            PayExtra = JsonConvert.SerializeObject(payment);
        }

        public RequestPayOrderBody(int amt, SandWxPublischPayment payment)
            : this(amt)
        {
            PayMode = "sand_wx";
            PayExtra = JsonConvert.SerializeObject(payment);
        }

        public RequestPayOrderBody(int amt, BankPcPayment payment)
            : this(amt)
        {
            PayMode = "bank_pc";
            PayExtra = JsonConvert.SerializeObject(payment);
        }

        public RequestPayOrderBody(int amt, SandWxAppPayment payment)
            : this(amt)
        {
            PayMode = "sand_wxsdk";
            PayExtra = JsonConvert.SerializeObject(payment);
        }

        private RequestPayOrderBody(int amount)
        {
            TotalAmount = amount.ToString().PadLeft(12, '0');
        }

        /// <summary>
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// </summary>
        public string TotalAmount { get; }

        /// <summary>
        ///     订单标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     订单描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public int TxnTimeOut { get; set; }

        /// <summary>
        ///     支付方式，请参考 Pay'Mode
        /// </summary>
        public string PayMode { get; }

        /// <summary>
        ///     支付扩展域
        /// </summary>
        public string PayExtra { get; }

        /// <summary>
        ///     客户端IP
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        ///     异步通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        ///     前台通知地址
        /// </summary>
        public string FrontUrl { get; set; }

        /// <summary>
        ///     商店门店编号
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        ///     商户终端号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        ///     操作员编号
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        ///     0-T1(默认) 1-T0 2-D0
        /// </summary>
        public ClearCycle ClearCycle { get; set; }

        /// <summary>
        ///     分账信息
        /// </summary>
        public string RoyaltyInfo { get; set; }

        /// <summary>
        ///     风控信息域
        /// </summary>
        public string RiskRateInfo { get; set; }

        /// <summary>
        ///     业务扩展参数
        /// </summary>
        public string BizExtendParams { get; set; }

        /// <summary>
        ///     商户扩展参数
        /// </summary>
        public string MerchExtendParams { get; set; }

        /// <summary>
        ///     扩展域
        /// </summary>
        public string Extend { get; set; }

        public void Valid()
        {
            if (string.IsNullOrEmpty(OrderCode)) SandParameterException.EmptyName("OrderCode");

            if (string.IsNullOrEmpty(Subject))
                SandParameterException.EmptyName("Subject");
            if (string.IsNullOrEmpty(Body))
                SandParameterException.EmptyName("Body");
            if (string.IsNullOrEmpty(PayMode))
                SandParameterException.EmptyName("PayMode");

            if (string.IsNullOrEmpty(ClientIp))
                SandParameterException.EmptyName("ClientIp");
            if (string.IsNullOrEmpty(NotifyUrl))
                SandParameterException.EmptyName("NotifyUrl");
        }
    }

    public class SandParameterException : Exception
    {
        public SandParameterException(string message)
            : base(message)
        {
        }

        public static SandParameterException EmptyName(string param)
        {
            return new SandParameterException("参数" + param + "不能为空");
        }
    }
}