using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Helper
{
    public class Webservice
    {
        private static string baseUrl;

        public object SendRequest()
        {
            throw new NotImplementedException();
        }

        public string loginUri = "login";
        public static JObject SendRequest(string requestURI, Dictionary<string, string> data)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(Webservice.baseUrl);

            var request = new RestRequest(requestURI, Method.POST);
            foreach (var param in data)
            {
                request.AddParameter(param.Key, param);
            }

            var response = client.Execute(request);
            var content = response.Content;
            JObject json = JObject.Parse(content);
            return json;
        }
    }
}
