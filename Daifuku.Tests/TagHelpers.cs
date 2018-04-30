using Daifuku.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Daifuku.Tests
{
    public class TagHelpers
    {
        //[Fact]
        //public void AddCssClassTag()
        //{
        //    var accth = new AddCssClassTagHelper();

        //    var attributes = new TagHelperAttributeList
        //    {
        //        new TagHelperAttribute("add-css-class-foo", true),
        //        new TagHelperAttribute("add-css-class-bar", false)
        //    };

        //    var tagHelperContext = new TagHelperContext(
        //                    attributes,
        //                    //new TagHelperAttributeList(),
        //                    new Dictionary<object, object>(),
        //                    Guid.NewGuid().ToString("N"));

        //    var tagHelperOutput = new TagHelperOutput("div",
        //        new TagHelperAttributeList(),
        //    (result, encoder) =>
        //    {
        //        var tagHelperContent = new DefaultTagHelperContent();
        //        tagHelperContent.SetHtmlContent(string.Empty);
        //        return Task.FromResult<TagHelperContent>(tagHelperContent);
        //    });
        //    accth.Process(tagHelperContext, tagHelperOutput);

        //    Assert.Equal("<p><em>Italic</em>, <strong>bold</strong>, and <code>monospace</code>.</p>", tagHelperOutput.Content.GetContent());
        //}
    }
}