
using System.Net;
using System.Net.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sand.Sdk
{
    public class HttpRequestHelper
    {
        public static JsonSerializerSettings serializerSettings;
        static HttpRequestHelper()
        {
            serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
        private readonly string _url;

        public HttpRequestHelper(string prefixUrl)
        {
            _url = prefixUrl.EndsWith('/') ? prefixUrl.TrimEnd('/') : prefixUrl;

        }

        public TReps Post<TReps, TRequest>(string url, MerchantInfo info, TRequest request)
        {
            url = url.StartsWith('/') ? url : "/" + url;
            var dataStr = JsonConvert.SerializeObject(request, serializerSettings);

            HttpClient client = new HttpClient();

            var data = new
            {
                sign = info.PrivateSignData(dataStr),
                data = dataStr
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(data, serializerSettings));
            var responseContent = client.PostAsync(_url + url, content).Result.Content;
            var json = responseContent.ReadAsStringAsync().Result;
            json = WebUtility.UrlDecode(json);
            var dict = System.Web.HttpUtility.ParseQueryString(json);
            var respData = dict["data"];
            return JsonConvert.DeserializeObject<TReps>(respData);
        }


    }
}