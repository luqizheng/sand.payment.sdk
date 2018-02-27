using Sand.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.SdkTest.Util
{
    public class Setting
    {
        public static string Host = "http://61.129.71.103:8003/gateway/api";
        public static string Pfx = "mid-test.pfx";
        public static string pub = "sand-test.cer";
        public static MerchantInfo MerchantInfo
        {
            get
            {
                return new MerchantInfo(Pfx, "123456", "888888888888888");
            }
        }
    }
}
