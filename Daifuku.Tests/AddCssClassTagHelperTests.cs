using Daifuku.Extensions;
using Daifuku.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Daifuku.Tests
{
    public class AddCssClassTagHelperTests
    {
        [Fact]
        public void AddCssClassTag()
        {
            var accth = new AddCssClassTagHelper
            {
                CssClass = "sakura-nene",
                ClassValues = new Dictionary<string, bool>
                {
                    { "foo", true },
                    { "bar", false }
                }
            };

            var tagHelperContext = new TagHelperContext(
                            new TagHelperAttributeList(),
                            new Dictionary<object, object>(),
                            Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput("div",
                new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent("");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            accth.Process(tagHelperContext, tagHelperOutput);

            var html = tagHelperOutput.ToHtml();
            Assert.Equal("<div class=\"sakura-nene foo\"></div>", html);
        }

        [Fact]
        public void AddCssClassTag2()
        {
            var accth = new AddCssClassTagHelper
            {
                ClassValues = new Dictionary<string, bool>
                {
                    { "foo", true },
                    { "bar", true }
                }
            };

            var tagHelperContext = new TagHelperContext(
                            new TagHelperAttributeList(),
                            new Dictionary<object, object>(),
                            Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput("div",
                new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent("");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            accth.Process(tagHelperContext, tagHelperOutput);

            var html = tagHelperOutput.ToHtml();
            Assert.Equal("<div class=\"foo bar\"></div>", html);
        }

        [Fact]
        public void AddCssClassTag3()
        {
            var accth = new AddCssClassTagHelper
            {
                CssClass = "none",
                ClassValues = new Dictionary<string, bool>
                {
                    { "bar", false }
                }
            };

            var tagHelperContext = new TagHelperContext(
                            new TagHelperAttributeList(),
                            new Dictionary<object, object>(),
                            Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput("div",
                new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent("");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            accth.Process(tagHelperContext, tagHelperOutput);

            var html = tagHelperOutput.ToHtml();
            Assert.Equal("<div class=\"none\"></div>", html);
        }
    }
}