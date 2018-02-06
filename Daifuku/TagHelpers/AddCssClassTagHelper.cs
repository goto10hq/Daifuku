using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Daifuku.TagHelpers
{
    [HtmlTargetElement("*", Attributes = ClassPrefix + "*")]
    public class AddCssClassTagHelper : TagHelper
    {
        const string ClassPrefix = "add-css-class-";

        [HtmlAttributeName("class")]
        public string CssClass { get; set; }

        IDictionary<string, bool> _classValues;

        [HtmlAttributeName("", DictionaryAttributePrefix = ClassPrefix)]
        public IDictionary<string, bool> ClassValues
        {
            get
            {
                return _classValues ?? (_classValues =
                    new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase));
            }
            set { _classValues = value; }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var items = _classValues.Where(e => e.Value).Select(e => e.Key).ToList();

            if (!string.IsNullOrEmpty(CssClass))
            {
                items.Insert(0, CssClass);
            }

            if (items.Any())
            {
                var classes = string.Join(" ", items.ToArray());
                output.Attributes.Add("class", classes);
            }
        }
    }
}