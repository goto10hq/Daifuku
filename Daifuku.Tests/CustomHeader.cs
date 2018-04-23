using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class CustomHeader : IClassFixture<HttpFixture>
    {
        readonly HttpFixture _http;

        public CustomHeader(HttpFixture http)
        {
            _http = http;
        }

        [Theory]
        [InlineData("X-Goto", "10")]
        public void ServerHeaderSet(string header, string value)
        {
            _http.Header.SetupSet(a => a[header] = value).Verifiable();
            AsyncTools.RunSync(() => new Middleware.CustomHeader(null, header, value).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}