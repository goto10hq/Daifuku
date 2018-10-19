using System.Collections.Generic;
using Xunit;

namespace Daifuku.Tests
{
    public class FeatureBuilderTests
    {
        [Fact]
        public void FeatureBuilderTest()
        {
            var builder = Builders.FeaturePolicyBuilder.Build(new FeaturePolicy
            {
                Autoplay = new HashSet<string> { Source.Self, "http://*.daifu.ku" },
                Geolocation = new HashSet<string> { Source.None }
            });

            Assert.Equal("autoplay 'self' http://*.daifu.ku; geolocation 'none';", builder);
        }
    }
}