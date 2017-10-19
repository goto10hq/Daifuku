using Xunit;
using Daifuku.Tests.Fixtures;
using Sushi2;

namespace Daifuku.Tests
{
    public class XssProtectionHeader : IClassFixture<HttpFixture>
    {
        HttpFixture _http;

        public XssProtectionHeader(HttpFixture http)
        {
            _http = http;
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