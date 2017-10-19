using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    /// <summary>
    /// Custom header.
    /// </summary>
    public class CustomHeader
    {
        readonly string _header;
        readonly RequestDelegate _next;
        readonly string _value;

        public CustomHeader(RequestDelegate next, string header, string value)
        {
            _value = value;
            _next = next;
            _header = header;
        }

        /// <summary>
        /// Invoke the specified context.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="context">Context.</param>
        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[_header] = _value;

            if (_next != null)
                await _next(context);
        }
    }
}