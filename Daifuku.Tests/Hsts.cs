using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class HstsHeader : IClassFixture<HttpFixture>
    {
        HttpFixture _http;

        public HstsHeader(HttpFixture http)
        {
            _http = http;
        }

        [Fact]
        public void HstsSet()
        {
            _http.Header.SetupSet(a => a[Constants.StrictTransportSecurity] = "max-age=31536000; includeSubDomains").Verifiable();
            AsyncTools.RunSync(() => new Middleware.Hsts(null, 31536000, true, false).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}