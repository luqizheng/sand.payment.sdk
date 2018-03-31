using System;

namespace Sand.Sdk
{
    public class PayMode
    {
        public const string H5 = "sand_h5";
        public const string BankPC = "bank_pc";

        public const string WechatPublic = "sand_wx";
        public const string WechatApp = "sand_wxsdk";
        public const string WechatH5 = "sand_wxh5";

        public const string SandCard = "sand_card";

        internal static string GetProduct(RequestPayOrderBody body)
        {
            switch (body.PayMode)
            {
                case H5:
                    return "00000024";
                case BankPC:
                    return "00000007";
                case WechatPublic:
                    return "00000005";

                case WechatApp:
                    return "00000024";

                case WechatH5:
                    return "00000025";
                case SandCard:
                    return "00000007";
            }

            throw new ArgumentException("无法识别" + body.PayMode + "对应德productId");
        }
    }
}