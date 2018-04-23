using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class ServerHeader : IClassFixture<HttpFixture>
    {
        readonly HttpFixture _http;

        public ServerHeader(HttpFixture http)
        {
            _http = http;
        }

        [Theory]
        [InlineData("Goto10")]
        public void ServerHeaderSet(string header)
        {
            _http.Header.SetupSet(a => a[Constants.ServerHeader] = header).Verifiable();
            AsyncTools.RunSync(() => new Middleware.ServerHeader(null, header).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}