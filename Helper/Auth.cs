using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
namespace Helper
{
    class Auth
    {
        public string _token { get; set; }
        public bool is_check(){
            if (String.IsNullOrEmpty(this._token))
                return false;
            else
                return true;
        }
        public bool check()
        {
            var service = new Webservice();
            var data = new Dictionary<string, string>;
            data.Add("token", this._token);
            JObject json = Webservice.SendRequest("check-login", data);

            if((string)json["status"] == "success")
            {
                return (bool)json["result"];
            }
            else
            {
                return false;
            }
        }
        public bool login(string username, string password)
        {
            var data = new Dictionary<string, string>;
            data.Add("id", username);
            data.Add("password", password);

            JObject json = Webservice.SendRequest("login", data);
            if ((string)json["status"] == "success")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
