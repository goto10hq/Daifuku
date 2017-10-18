using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class XPoweredByHeader : IClassFixture<HttpFixture>
    {
        HttpFixture _http;

        public XPoweredByHeader(HttpFixture http)
        {
            _http = http;
        }

        [Theory]
        [InlineData("Goto10")]
        public void XPoweredByHeaderSet(string header)
        {
            _http.Header.SetupSet(a => a[Constants.XPoweredBy] = header).Verifiable();
            AsyncTools.RunSync(() => new Middleware.XPoweredByHeader(null, header).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}