using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class ExpectCt
    {
        readonly RequestDelegate _next;
        readonly ulong _maxAge;
        readonly string _reportUri;
        readonly bool _enforce;

        public ExpectCt(RequestDelegate next, ulong maxAge, string reportUri, bool enforce = false)
        {
            _next = next;
            _maxAge = maxAge;
            _reportUri = reportUri;
            _enforce = enforce;
        }

        /// <summary>
        /// Invoke the specified context.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="context">Context.</param>
        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ExpectCt] = "max-age=" +
                _maxAge +
                (!string.IsNullOrWhiteSpace(_reportUri) ? $"; report-uri=\"{_reportUri}\"" : string.Empty) +
                (_enforce ? "; enforce" : string.Empty);

            if (_next != null)
                await _next(context);
        }
    }
}