using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Sdk
{
    public class RequestQueryPayment
    {
        public RequestHeader Header { get; set; }
        public RequestQueryBody Body { get; set; }

    }
    public class ResponseQueryPayment
    {
        public ResponseQueryBody Body { get; set; }
        public ResponseHeader Header { get; set; }
    }


    public class RequestQueryBody
    {
        public string orderCode { get; set; }
    }
    public class ResponseQueryBody
    {

        public string oriOrderCode { get; set; }
        public string oriRespCode { get; set; }
        public string oriRespMsg { get; set; }
        public string totalAmount { get; set; }
        public string orderStatus { get; set; }
        public string buyerPayAmount { get; set; }
        public string discAmount { get; set; }
        public string payTime { get; set; }
        public string clearDate { get; set; }
        public string extend { get; set; }
    }
}
