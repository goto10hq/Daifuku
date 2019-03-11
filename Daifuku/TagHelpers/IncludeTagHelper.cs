using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using HtmlAgilityPack;

namespace Daifuku.TagHelpers
{
    [HtmlTargetElement("include")]
    public class IncludeTagHelper : TagHelper
    {
        readonly IHostingEnvironment _hostingEnvironment;

        [HtmlAttributeName("path")]
        public string Path { get; set; }

        public IncludeTagHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, Path);
            var content = string.Empty;

            if (!context.AllAttributes.Any())
            {
                output.Content.SetHtmlContent(string.Empty);
            }
            else if (!context.AllAttributes.Where(a => a.Name != "path").Any())
            {
                content = File.ReadAllText(path);
                output.Content.SetHtmlContent(content);
            }
            else
            {
                content = File.ReadAllText(path);
                var html = new HtmlDocument();
                html.LoadHtml(content);

                if (html?.DocumentNode?.FirstChild != null)
                {
                    var node = html.DocumentNode.FirstChild;

                    foreach (var a in context.AllAttributes.Where(a => a.Name != "path"))
                    {
                        node.SetAttributeValue(a.Name, a.Value.ToString());
                    }

                    output.Content.SetHtmlContent(node.WriteTo());
                }
                else
                {
                    output.Content.SetHtmlContent(content);
                }
            }
        }
    }
}