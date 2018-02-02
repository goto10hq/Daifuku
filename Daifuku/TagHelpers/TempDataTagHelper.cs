using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Daifuku.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "temp-data-key")]
    public class TempDataTagHelper : TagHelper
    {
        [HtmlAttributeName("temp-data-key")]
        public string Key { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected ITempDataDictionary TempData => ViewContext.TempData;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            if (TempData[Key] == null)
            {
                output.SuppressOutput();
            }
            else
            {
                output.Content.SetContent(TempData[Key].ToString());
            }
        }
    }
}