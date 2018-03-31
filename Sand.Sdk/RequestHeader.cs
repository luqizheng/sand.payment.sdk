using System;

namespace Sand.Sdk
{
    public class RequestHeader
    {
        /// <summary>
        ///     平台id
        /// </summary>
        public string plMid { get; set; }

        /// <summary>
        ///     渠道类型
        /// </summary>
        public string ChannelType { get; set; }

        /// <summary>
        ///     商户id
        /// </summary>
        public string Mid { get; set; }

        /// <summary>
        ///     接入类型：
        ///     1-普通商户接入
        ///     2-平台商户接入
        /// </summary>
        public AccessType AccessType { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string ProductId { get; set; }

        public string Method { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; } = "1.0";
        /// <summary>
        /// 请求时间
        /// </summary>
        public string ReqTime { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}