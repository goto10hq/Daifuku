using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    /// <summary>
    /// No sniff header.
    /// </summary>
    public class NoSniff
    {
        readonly RequestDelegate _next;
        readonly bool _use;

        public NoSniff(RequestDelegate next, bool use = true)
        {
            _use = use;
            _next = next;
        }

        /// <summary>
        /// Invoke the specified context.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="context">Context.</param>
        public async Task Invoke(HttpContext context)
        {
            if (_use)
                context.Response.Headers[Constants.XContentTypeOptions] = Constants.NoSniff;
            else
                context.Response.Headers.Remove(Constants.XContentTypeOptions);

            if (_next != null)
                await _next(context).ConfigureAwait(false);
        }
    }
}