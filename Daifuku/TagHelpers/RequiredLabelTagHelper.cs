using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace Daifuku.TagHelpers
{
    [HtmlTargetElement("required-label", Attributes = ForAttributeName)]
    public class RequiredLabelTagHelper : LabelTagHelper
    {
        const string ForAttributeName = "asp-for";

        [HtmlAttributeName("is-required")]
        public bool? IsRequired { get; set; }

        public RequiredLabelTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "label";

            if ((For.Metadata.IsRequired && !IsRequired.HasValue) ||
                (IsRequired.HasValue && IsRequired == true))
            {
                CreateOrMergeAttribute("class", "required", output);
            }

            return base.ProcessAsync(context, output);
        }

        void CreateOrMergeAttribute(string name, object content, TagHelperOutput output)
        {
            var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == name);

            if (currentAttribute == null)
            {
                var attribute = new TagHelperAttribute(name, content);
                output.Attributes.Add(attribute);
            }
            else
            {
                var newAttribute = new TagHelperAttribute(
                    name,
                    $"{currentAttribute.Value.ToString()} {content.ToString()}",
                    currentAttribute.ValueStyle);
                output.Attributes.Remove(currentAttribute);
                output.Attributes.Add(newAttribute);
            }
        }
    }
}