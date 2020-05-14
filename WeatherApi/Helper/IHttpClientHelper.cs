using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Model;

namespace WeatherApi.Helper
{
    public interface IHttpClientHelper
    {
        Task<HttpResponseMessage> SendHttpRequest(Method method, string requestUrl, object body, string baseUrl);
    }

    
}
