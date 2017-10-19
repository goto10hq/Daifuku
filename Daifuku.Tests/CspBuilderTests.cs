using System.Collections.Generic;
using Xunit;

namespace Daifuku.Tests
{
    public class CspBuilderTests
    {
        [Fact]
        public void DefaultBuilderTests()
        {
            var builder = Builders.ContentSecurityPolicyBuilder.Build(new ContentSecurityPolicy
            {
                DefaultSrc = new HashSet<string> { CspConstants.Self, CspConstants.None, "http://*.daifu.ku" },
                ScriptSrc = new HashSet<string> { "http://*.daifu.ku" },
                StyleSrc = new HashSet<string> { "http://*.daifu.ku" },
                ImgSrc = new HashSet<string> { "http://*.daifu.ku" },
                ConnectSrc = new HashSet<string> { "http://*.daifu.ku" },
                FontSrc = new HashSet<string> { "http://*.daifu.ku" },
                ObjectSrc = new HashSet<string> { "http://*.daifu.ku" },
                MediaSrc = new HashSet<string> { "http://*.daifu.ku" },
                ChildSrc = new HashSet<string> { "http://*.daifu.ku" },
                FormAction = new HashSet<string> { "http://*.daifu.ku" },
                FrameAncestors = new HashSet<string> { "http://*.daifu.ku" },
                PluginTypes = new HashSet<string> { "http://*.daifu.ku" },
                Sandbox = SandboxOptions.AllowPointerLock
            });

            Assert.Equal(@"default-src 'self' 'none' http://*.daifu.ku; script-src http://*.daifu.ku; style-src http://*.daifu.ku; img-src http://*.daifu.ku; connect-src http://*.daifu.ku; font-src http://*.daifu.ku; object-src http://*.daifu.ku; media-src http://*.daifu.ku; child-src http://*.daifu.ku; form-action http://*.daifu.ku; frame-ancestors http://*.daifu.ku; sandbox allow-pointer-lock; plugin-types http://*.daifu.ku;", builder);
        }
    }
}