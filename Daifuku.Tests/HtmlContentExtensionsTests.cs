using Daifuku.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Xunit;

namespace Daifuku.Tests
{
    public class HtmlContentExtensionsTests
    {
        [Fact]
        public void TestSpan()
        {
            var span = new TagBuilder("span");
            span.InnerHtml.Append("hello");
            Assert.Equal("<span>hello</span>", span.ToHtml());
        }

        [Fact]
        public void TestSpanWithHtmlContent()
        {
            var span = new TagBuilder("span");
            span.InnerHtml.Append("hello&hi");
            Assert.Equal("<span>hello&amp;hi</span>", span.ToHtml());
        }
    }
}