using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Sdk.CheckoutCounters
{
    
    public class CheckoutCounter
    {
        public string orderCode { get; set; }
        public int totalAmount { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string txnTimeOut { get; set; }
        public string payMode { get; set; }
        public string payExtra { get; set; }
        public string clientIp { get; set; }
        public string notifyUrl { get; set; }
        public string frontUrl { get; set; }
        public string storeId { get; set; }
        public string terminalId { get; set; }
        public string operatorId { get; set; }
        /// <summary>
        /// 0-T1(默认) 1-T0 2-D0
        /// </summary>
        public int clearCycle { get; set; }
        public string riskRateInfo { get; set; }
        public string bizExtendParams { get; set; }
        public string merchExtendParams { get; set; }
        public string extend { get; set; }
    }
}
