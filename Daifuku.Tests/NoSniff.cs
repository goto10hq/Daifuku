using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class NoSniff : IClassFixture<HttpFixture>
    {
        HttpFixture _http;

        public NoSniff(HttpFixture http)
        {
            _http = http;
        }

        [Fact]
        public void ServerHeaderSet()
        {
            _http.Header.SetupSet(a => a[Constants.XContentTypeOptions] = Constants.NoSniff).Verifiable();
            AsyncTools.RunSync(() => new Middleware.NoSniff(null).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}