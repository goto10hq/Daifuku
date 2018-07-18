//using Daifuku.Extensions;
//using Daifuku.TagHelpers;
//using Daifuku.Tests.Helpers;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.AspNetCore.Razor.TagHelpers;
//using Sushi2;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Threading.Tasks;
//using Xunit;

//namespace Daifuku.Tests
//{
//    public class RequiredLabelTagHelperTests
//    {
//        static ModelExpression CreateModelExpression(string name)
//        {
//            var modelMetadataProvider = new EmptyModelMetadataProvider();

//            var me = new ModelExpression(name, modelMetadataProvider
//                .GetModelExplorerForType(typeof(Model), null)
//                .GetExplorerForProperty(name));

//            var dn = me.ModelExplorer.Metadata.GetDisplayName();

//            return me;
//        }

//        class Model
//        {
//            [Required]
//            public string Moeta { get; set; }

//            public string Moeta2 { get; set; }
//        }

//        [Theory]
//        //[InlineData("Moeta", null, true)]
//        //[InlineData("Moeta2", null, false)]
//        [InlineData("Moeta", true, true)]
//        [InlineData("Moeta2", true, true)]
//        //[InlineData("Moeta", false, false)]
//        //[InlineData("Moeta2", false, false)]
//        public void RequiredSet(string property, bool? isRequired, bool res)
//        {
//            var metadataProvider = new EmptyModelMetadataProvider();
//            var th = new RequiredLabelTagHelper(new TestableHtmlGenerator(metadataProvider))
//            {
//                IsRequired = isRequired,
//                For = CreateModelExpression(property)
//            };

//            var tagHelperContext = new TagHelperContext(
//                            new TagHelperAttributeList(),
//                            new Dictionary<object, object>(),
//                            Guid.NewGuid().ToString("N", Cultures.Invariant));

//            var tagHelperOutput = new TagHelperOutput("required-label",
//                new TagHelperAttributeList(),
//            (result, encoder) =>
//            {
//                var tagHelperContent = new DefaultTagHelperContent();
//                tagHelperContent.SetHtmlContent("");
//                return Task.FromResult<TagHelperContent>(tagHelperContent);
//            });
//            th.Process(tagHelperContext, tagHelperOutput);

//            var html = tagHelperOutput.ToHtml();

//            if (res)
//                Assert.Equal("<label class=\"required\"></label>", html);
//            else
//                Assert.Equal("<label></label>", html);
//        }
//    }
//}