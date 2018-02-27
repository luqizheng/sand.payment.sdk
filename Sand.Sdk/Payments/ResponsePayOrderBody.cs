namespace Sand.Sdk
{
    public class ResponsePayOrderBody
    {
        public string orderCode { get; set; }
        public string totalAmount { get; set; }
        public string credential { get; set; }
        public string traceNo { get; set; }
        public string buyerPayAmount { get; set; }
        public string discAmount { get; set; }
        public string payTime { get; set; }
        public string clearDate { get; set; }
    }
}
