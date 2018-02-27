using System;

namespace Sand.Sdk
{
    public class ResponseHeader
    {
        public string Version { get; set; }
        public string RespTime { get; set; }
        public string RespCode { get; set; }
        public string RespMsg { get; set; }
    }

    public class RequestHeader
    {
        /// <summary>
        /// 平台id
        /// </summary>
        public string plMid { get; set; }
        /// <summary>
        /// 渠道类型
        /// </summary>
        public string ChannelType { get; set; }
        /// <summary>
        /// 商户id
        /// </summary>
        public string Mid { get; set; }
        public string AccessType { get; set; }
        public string ProductId { get; set; }
        public string Method { get; set; }
        public string Version { get; set; } = "1.0";

        public string ReqTime { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
    }

    public class PayMode
    {
        public const string H5 = "sand_h5";
        public const string BankPC = "bank_pc";

        internal static string GetProduct(RequestPayOrderBody body)
        {
            switch (body.PayMode)
            {
                case PayMode.H5:
                    return "00000024";
                case PayMode.BankPC:
                    return "00000007";
                case PayMode.WechatPublic:
                    return "00000005";

                case PayMode.WechatApp:
                    return "00000024";

                case PayMode.WechatH5:
                    return "00000025";
                case PayMode.SandCard:
                    return "00000007";
            }
            throw new ArgumentException("无法识别" + body.PayMode + "对应德productId");
        }

        public const string WechatPublic = "sand_wx";
        public const string WechatApp = "sand_wxsdk";
        public const string WechatH5 = "sand_wxh5";

        public const string SandCard = "sand_card";

    }
}
