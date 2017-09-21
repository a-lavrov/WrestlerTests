using RestSharp;
using RestSharp.Deserializers;
using System;

namespace WrestlerTests.APITests.APIs
{
    public class BaseAPI
    {
        private RestResponseCookie _cookie;
        protected RestResponseCookie Cookie => _cookie ?? (_cookie = new Lazy<RestResponseCookie>(() => Authenticate()).Value);
        
        private RestClient _client;
        protected RestClient Client => _client ?? (_client = new Lazy<RestClient>(
            () =>
            {
                var client = new RestClient("http://streamtv.net.ua/base/php");
                client.AddHandler("text/html", new JsonDeserializer());
                return client;
            }).Value);

        protected RestResponseCookie Authenticate()
        {
            var request = new RestRequest()
            {
                Method = Method.POST,
                Resource = "/login.php"
            };

            string creds = "{\"username\":\"auto\",\"password\":\"test\"}";
            request.AddParameter("application/json", creds, ParameterType.RequestBody);
            var responce = Client.Execute(request);

            if (responce.Cookies.Count > 0)
            {
                return responce.Cookies[0];
            }
            return null;
        }

        protected T Execute<T>(RestRequest request) where T : new()
        {
            if (Cookie != null)
            {
                request.AddCookie(Cookie.Name, Cookie.Value);
            }

            var response = Client.Execute<T>(request);
            
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response. Check inner details for more info.";
                var e = new ApplicationException(message + $" Response content: {response.Content}", response.ErrorException);
                throw e;
            }

            return response.Data;
        }
        

        
    }
}
