using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Model;

namespace WeatherApi.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientHelper(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<HttpResponseMessage> SendHttpRequest(Method method, string requestUrl, object body, string baseUrl)
        {
            HttpResponseMessage httpResponseMessage = null;
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            switch (method) {
                case Method.Get:
                    httpResponseMessage = await httpClient.GetAsync(requestUrl);
                    break;
            }
            return httpResponseMessage;
        }
    }
}
