using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Daifuku.TagHelpers
{
    [HtmlTargetElement("*", Attributes = DisplayNameForAttribute)]
    public class DisplayNameForTagHelper : TagHelper
    {
        const string DisplayNameForAttribute = "asp-display-name-for";

        [HtmlAttributeName(DisplayNameForAttribute)]
        public ModelExpression DisplayNameFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var text = DisplayNameFor.ModelExplorer.Metadata.DisplayName ?? DisplayNameFor.ModelExplorer.Metadata.PropertyName;

            output.Content.SetContent(text);
        }
    }
}