using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sand.Sdk
{
    public class MerchantInfo
    {
        public AccessType AccessType { get; set; }
        public string PfxPath { get; set; }
        public string MerchantId { get; set; }
        public string Password { get; set; }

        public string PlatformId { get; set; }

        public MerchantInfo(string pfxPath, string password, string merchantId,
           string platformId)
          : this(pfxPath, password, merchantId)
        {
            if (string.IsNullOrEmpty(merchantId))
            {
                throw new ArgumentException("message", nameof(merchantId));
            }

            if (string.IsNullOrEmpty(platformId))
            {
                throw new ArgumentException("message", nameof(platformId));
            }

            this.AccessType = AccessType.Platform;
            this.PlatformId = platformId;
        }
        public MerchantInfo(string pfxPath, string password, string merchantId)
        {
            this.PfxPath = pfxPath;
            this.Password = password;
            this.MerchantId = merchantId;
            if (!File.Exists(pfxPath))
                throw new FileNotFoundException("找不到证书文件", pfxPath);

        }

       
        private RSA GetPrivateKey()
        {
            var certificate = new X509Certificate2(PfxPath, Password, X509KeyStorageFlags.Exportable);
            return certificate.GetRSAPrivateKey();

        }

        public string PrivateSignData(string strEncryptString)
        {
            var privateKey = GetPrivateKey();
            var bytes = Encoding.UTF8.GetBytes(strEncryptString);
            var provider = new RSACryptoServiceProvider();
            provider.ImportParameters(privateKey.ExportParameters(true));
            var c = provider.SignData(bytes, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(c);
        }

    }
}
