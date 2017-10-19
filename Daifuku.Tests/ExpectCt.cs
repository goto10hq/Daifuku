using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class ExpectCt : IClassFixture<HttpFixture>
    {
        HttpFixture _http;

        public ExpectCt(HttpFixture http)
        {
            _http = http;
        }

        [Fact]
        public void ExpectCtSet()
        {
            _http.Header.SetupSet(a => a[Constants.ExpectCt] = "max-age=86400; report-uri=\"https://foo.example/report\"").Verifiable();
            AsyncTools.RunSync(() => new Middleware.ExpectCt(null, 86400, "https://foo.example/report", false).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}