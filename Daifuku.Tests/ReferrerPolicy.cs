using Xunit;
using Sushi2;
using Daifuku.Tests.Fixtures;

namespace Daifuku.Tests
{
    public class ReferrerPolicyHeader : IClassFixture<HttpFixture>
    {
        readonly HttpFixture _http;

        public ReferrerPolicyHeader(HttpFixture http)
        {
            _http = http;
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
    }
}