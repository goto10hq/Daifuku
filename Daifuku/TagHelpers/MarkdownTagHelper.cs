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
            _pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSoftlineBreakAsHardlineBreak()
                .Build();
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output).ConfigureAwait(false);

            string content = null;
            if (Markdown != null)
                content = Markdown.Model?.ToString();

            if (content == null)
            {
                var c = await output.GetChildContentAsync(NullHtmlEncoder.Default).ConfigureAwait(false);
                content = c.GetContent(NullHtmlEncoder.Default);
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