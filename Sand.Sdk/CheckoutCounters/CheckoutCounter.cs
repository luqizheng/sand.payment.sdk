using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sand.Sdk.CheckoutCounters
{

    public class CheckoutCounter
    {
        public CheckoutCounter(int amt, SandCardPaymemnt payment)
            : this(amt)
        {
            payMode = "sand_card";
            payExtra = JsonConvert.SerializeObject(payment);
        }

        public CheckoutCounter(int amt, SandH5Payment payment)
            : this(amt)
        {
            payMode = "sand_h5";
            payExtra = JsonConvert.SerializeObject(payment);
        }

        public CheckoutCounter(int amt, SandWxH5 payment)
            : this(amt)
        {
            payMode = "sand_wxh5";
            payExtra = JsonConvert.SerializeObject(payment);
        }

        public CheckoutCounter(int amt, SandWxPublischPayment payment)
            : this(amt)
        {
            payMode = "sand_wx";
            payExtra = JsonConvert.SerializeObject(payment);
        }

        public CheckoutCounter(int amt, BankPcPayment payment)
            : this(amt)
        {
            payMode = "bank_pc";
            payExtra = JsonConvert.SerializeObject(payment);
        }

        public CheckoutCounter(int amt, SandWxAppPayment payment)
            : this(amt)
        {
            payMode = "sand_wxsdk";
            payExtra = JsonConvert.SerializeObject(payment);
        }
        private CheckoutCounter(int amount)
        {
            totalAmount = amount;
        }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string orderCode { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public int totalAmount { get; set; }
        /// <summary>
        /// 订单标题
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 订单描述
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 订单超时时间
        /// </summary>
        public string txnTimeOut { get; set; }
        /// <summary>
        /// 支付模式
        /// </summary>
        public string payMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payExtra { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clientIp { get; set; }
        public string notifyUrl { get; set; }
        public string frontUrl { get; set; }
        public string storeId { get; set; }
        public string terminalId { get; set; }
        public string operatorId { get; set; }
        /// <summary>
        /// 0-T1(默认) 1-T0 2-D0
        /// </summary>
        public ClearCycle clearCycle { get; set; }
        public string riskRateInfo { get; set; }
        public string bizExtendParams { get; set; }
        public string merchExtendParams { get; set; }
        public string extend { get; set; }
    }
}
