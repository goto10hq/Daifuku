using Microsoft.AspNetCore.Html;
using System;
using System.IO;

namespace Daifuku.Extensions
{
    public static class HtmlContentExtensions
    {
        public static string ToHtml(this IHtmlContent htmlContent)
        {
            if (htmlContent == null)
                throw new ArgumentNullException(nameof(htmlContent));

            var htmlOutput = string.Empty;

            using (var writer = new StringWriter())
            {
                htmlContent.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                htmlOutput = writer.ToString();
            }

            return htmlOutput;
        }
    }
}