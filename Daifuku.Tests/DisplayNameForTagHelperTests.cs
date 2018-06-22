using Daifuku.Extensions;
using Daifuku.TagHelpers;
using Daifuku.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sushi2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace Daifuku.Tests
{
    public class DisplayNameForTagHelperTests
    {
        static ModelExpression CreateModelExpression(string name)
        {
            var modelMetadataProvider = new EmptyModelMetadataProvider();

            var me = new ModelExpression(name, modelMetadataProvider
                .GetModelExplorerForType(typeof(Model), null)
                .GetExplorerForProperty(name)
                );

            var dn = me.ModelExplorer.Metadata.GetDisplayName();

            return me;
        }

        class Model
        {
            [DisplayName("Kaos")]
            public string Moeta { get; set; }

            [Display(Name = "Abababa")]
            public string Moeta2 { get; set; }

            public int Something { get; set; }
        }

        [Theory]
        [InlineData("Moeta", "Kaos")]
        [InlineData("Moeta2", "Abababa")]
        public void DisplayNameForSet(string property, string output)
        {
            var m = new Model();

            var th = new DisplayNameForTagHelper
            {
                DisplayNameFor = CreateModelExpression(property)
            };

            var tagHelperContext = new TagHelperContext(
                            new TagHelperAttributeList(),
                            new Dictionary<object, object>(),
                            Guid.NewGuid().ToString("N", Cultures.Invariant));

            var tagHelperOutput = new TagHelperOutput("div",
                new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent("");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            th.Process(tagHelperContext, tagHelperOutput);

            var html = tagHelperOutput.ToHtml();
            Assert.Equal($"<div>{output}</div>", html);
        }

        [Fact]
        public void DisplayNameForNotSet()
        {
            var m = new Model();

            var th = new DisplayNameForTagHelper
            {
                DisplayNameFor = CreateModelExpression("Something")
            };

            var tagHelperContext = new TagHelperContext(
                            new TagHelperAttributeList(),
                            new Dictionary<object, object>(),
                            Guid.NewGuid().ToString("N", Cultures.Invariant));

            var tagHelperOutput = new TagHelperOutput("div",
                new TagHelperAttributeList(),
            (result, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetHtmlContent("");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
            th.Process(tagHelperContext, tagHelperOutput);

            var html = tagHelperOutput.ToHtml();
            Assert.Equal("<div>Something</div>", html);
        }
    }
}