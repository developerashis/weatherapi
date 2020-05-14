using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherApi.Helper;
using WeatherApi.Model;
using Xunit;

namespace Test.WeatherApi
{
    public class HttpClientHelperTest
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        public HttpClientHelperTest() {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _httpClientHelper = new HttpClientHelper(_httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task Test_SendHttpRequest_Should_Return_HttpResponse()
        {
            Mock<HttpMessageHandler> httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK, Content = new StringContent("'name':'delhi', 'temp':'40.0'") });
            var client = new HttpClient(httpMessageHandlerMock.Object);
            _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            var response = await _httpClientHelper.SendHttpRequest(Method.Get, "api/get", null, "https://localhost:9090/");
            Assert.True(response != null && HttpStatusCode.OK == response.StatusCode);
        }
    }
}
