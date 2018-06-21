using Daifuku.Extensions;
using Daifuku.TagHelpers;
using Daifuku.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace Daifuku.Tests
{
    public class DisplayNameForTagHelperTests
    {
        static ModelExpression CreateModelExpression(string name)
        {
            var modelMetadataProvider = new EmptyModelMetadataProvider();

            return new ModelExpression(name, modelMetadataProvider.GetModelExplorerForType(typeof(Model), new Model()).GetExplorerForProperty(name));
            //return new ModelExpression(name, modelMetadataProvider.GetModelExplorerForType(typeof(Model), new Model()));
        }

        public class Model
        {
            [DisplayName("Kaos")]
            public string Moeta { get; set; }

            public int Something { get; set; }
        }

        //[Fact]
        // TODO: fix
        public void DisplayNameForSet()
        {
            var m = new Model();

            var th = new DisplayNameForTagHelper
            {
                DisplayNameFor = CreateModelExpression("Moeta")
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
            th.Process(tagHelperContext, tagHelperOutput);

            var html = tagHelperOutput.ToHtml();
            Assert.Equal("<div>Kaos</div>", html);
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
                            Guid.NewGuid().ToString("N"));

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