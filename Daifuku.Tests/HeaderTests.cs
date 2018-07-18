using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class HeaderTests : IClassFixture<HttpFixture>
    {
        readonly HttpFixture _http;

        public HeaderTests(HttpFixture http)
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

        [Theory]
        [InlineData("X-Goto", "10")]
        public void CustomHeaderSet(string header, string value)
        {
            _http.Header.SetupSet(a => a[header] = value).Verifiable();
            AsyncTools.RunSync(() => new Middleware.CustomHeader(null, header, value).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Fact]
        public void HstsSet()
        {
            _http.Header.SetupSet(a => a[Constants.StrictTransportSecurity] = "max-age=31536000; includeSubDomains").Verifiable();
            AsyncTools.RunSync(() => new Middleware.Hsts(null, 31536000, true, false).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Fact]
        public void NoSniff()
        {
            _http.Header.SetupSet(a => a[Constants.XContentTypeOptions] = Constants.NoSniff).Verifiable();
            AsyncTools.RunSync(() => new Middleware.NoSniff(null).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Theory]
        [InlineData(ReferrerPolicy.NoReferrer, "no-referrer")]
        [InlineData(ReferrerPolicy.StrictOriginWhenCrossOrigin, "strict-origin-when-cross-origin")]
        public void ReferrerPolicyMapping(ReferrerPolicy policy, string val)
        {
            Assert.Equal(val, Constants.Referrers[policy]);
        }

        [Theory]
        [InlineData(ReferrerPolicy.NoReferrer)]
        public void ReferrerPolicySet(ReferrerPolicy policy)
        {
            _http.Header.SetupSet(a => a[Constants.ServerHeader] = Constants.Referrers[policy]).Verifiable();
            AsyncTools.RunSync(() => new Middleware.ServerHeader(null, Constants.Referrers[policy]).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Theory]
        [InlineData("Goto10")]
        public void ServerHeaderSet(string header)
        {
            _http.Header.SetupSet(a => a[Constants.ServerHeader] = header).Verifiable();
            AsyncTools.RunSync(() => new Middleware.ServerHeader(null, header).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Theory]
        [InlineData("Goto10")]
        public void XPoweredByHeaderSet(string header)
        {
            _http.Header.SetupSet(a => a[Constants.XPoweredBy] = header).Verifiable();
            AsyncTools.RunSync(() => new Middleware.XPoweredBy(null, header).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Fact]
        public void ExpectCtSet()
        {
            _http.Header.SetupSet(a => a[Constants.ExpectCt] = "max-age=86400; report-uri=\"https://foo.example/report\"").Verifiable();
            AsyncTools.RunSync(() => new Middleware.ExpectCt(null, 86400, "https://foo.example/report", false).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }

        [Theory]
        [InlineData(XssProtection.Disabled, "0")]
        [InlineData(XssProtection.EnabledWithBlock, "1; mode=block")]
        public void XssProtectionMapping(XssProtection protection, string val)
        {
            Assert.Equal(val, Constants.XssProtections[protection]);
        }

        [Theory]
        [InlineData(XssProtection.EnabledWithBlock)]
        public void XssProtectionSet(XssProtection protection)
        {
            _http.Header.SetupSet(a => a[Constants.XssProtection] = Constants.XssProtections[protection]).Verifiable();
            AsyncTools.RunSync(() => new Middleware.XssProtection(null, protection).Invoke(_http.ContextMock.Object));
            _http.Header.Verify();
        }
    }
}