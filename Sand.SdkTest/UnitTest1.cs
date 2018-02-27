using Sand.Sdk;
using Sand.SdkTest.Util;
using System;
using Xunit;

namespace Sand.SdkTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            SandPayService service = new SandPayService(Setting.Host);
            var body = new RequestPayOrderBody(1, new BankPcPayment()
            {
                BankCode = "",
                PayType = 2,
            })
            {
                OrderCode = Guid.NewGuid().ToString("N"),
                Subject = "≤‚ ‘",
                Body = "≤‚ ‘",
                NotifyUrl="http://127.0.0.1",
                ClientIp="127.0.0.1"
            };
            service.PayByGateway(Setting.MerchantInfo, body);
        }
    }
}
