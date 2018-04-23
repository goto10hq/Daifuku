using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class XPoweredBy : IClassFixture<HttpFixture>
    {
        readonly HttpFixture _http;

        public XPoweredBy(HttpFixture http)
        {
            _http = http;
        }

        [Theory]
        [InlineData("Goto10")]
        public void XPoweredByHeaderSet(string header)
        {
            _http.Header.SetupSet(a => a[Constants.XPoweredBy] = header).Verifiable();
            AsyncTools.RunSync(() => new Middleware.XPoweredBy(null, header).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}