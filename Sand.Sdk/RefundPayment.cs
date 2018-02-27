using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Sdk
{
    public class RequestRefundPayment
    {
        public RequestHeader Header { get; set; }

        public RequestRefundBody Body { get; set; }
    }

    public class ResponseRefundPayment
    {
        public ResponseHeader Header { get; set; }

        public ResponseRefudBody Body { get; set; }

    }

    public class RequestRefundBody
    {
        public string orderCode { get; set; }
        public string oriOrderCode { get; set; }
        public string refundAmount { get; set; }
        public string notifyUrl { get; set; }
        public string refundReason { get; set; }
        public string extend { get; set; }
    }

    public class ResponseRefudBody
    {
        public string orderCode { get; set; }
        public string traceNo { get; set; }
        public string refundAmount { get; set; }
        public string surplusAmount { get; set; }
        public string refundTime { get; set; }
        public string clearDate { get; set; }
        public string extend { get; set; }
    }
}
