using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using Markdig;

namespace Daifuku.TagHelpers
{
    [HtmlTargetElement("markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        readonly MarkdownPipeline _pipeline;

        [HtmlAttributeName("markdown")]
        public ModelExpression Markdown { get; set; }

        public MarkdownTagHelper()
        {
            _pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output).ConfigureAwait(false);

            string content = null;
            if (Markdown != null)
                content = Markdown.Model?.ToString();

            if (content == null)
            {
                content = (await output.GetChildContentAsync(NullHtmlEncoder.Default).ConfigureAwait(false))
                               .GetContent(NullHtmlEncoder.Default);
            }

            if (string.IsNullOrEmpty(content))
                return;

            string markdown = content.Trim();

            var html = Markdig.Markdown.ToHtml(markdown, _pipeline);

            output.TagName = null;
            output.Content.SetHtmlContent(html);
        }
    }
}