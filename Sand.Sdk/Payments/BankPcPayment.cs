namespace Sand.Sdk
{
    public class BankPcPayment
    {
        public BankPcPayment()
        {

        }
        /// <summary>
        /// 1：网银支付（借记卡）
        /// 2：网银支付（贷记卡）
        /// 3：混合通道（借/贷记卡均可使用）		
        /// 4：B2B支付(对公业务只能选4)
        /// </summary>
        public int PayType { get; set; }
        public string BankCode { get; set; }
    }
}
