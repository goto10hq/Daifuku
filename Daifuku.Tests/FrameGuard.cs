using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class FrameGuard : IClassFixture<HttpFixture>
    {
        HttpFixture _http;

        public FrameGuard(HttpFixture http)
        {
            _http = http;
        }

        [Fact]
        public void FrameGuardSet()
        {
            _http.Header.SetupSet(a => a[Constants.FrameGuardHeader] = Constants.FrameGuards[Daifuku.FrameGuard.SameOrigin]).Verifiable();
            AsyncTools.RunSync(() => new Middleware.FrameGuard(null, new FrameGuardOptions(Daifuku.FrameGuard.SameOrigin)).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Fact]
        public void FrameGuardWithDomainSet()
        {
            _http.Header.SetupSet(a => a[Constants.FrameGuardHeader] = Constants.FrameGuards[Daifuku.FrameGuard.AllowFrom] + " " + "http://www.goto10.cz").Verifiable();
            AsyncTools.RunSync(() => new Middleware.FrameGuard(null, new FrameGuardOptions("http://www.goto10.cz")).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}