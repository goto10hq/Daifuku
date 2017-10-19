using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    /// <summary>
    /// HSTS header.
    /// </summary>
    public class Hsts
    {
        readonly RequestDelegate _next;
        readonly ulong _maxAge;
        readonly bool _includeSubDomains;
        readonly bool _preload;

        public Hsts(RequestDelegate next, ulong maxAge = 31536000, bool includeSubDomains = false, bool preload = false)
        {
            _preload = preload;
            _includeSubDomains = includeSubDomains;
            _maxAge = maxAge;
            _next = next;
        }

        /// <summary>
        /// Invoke the specified context.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="context">Context.</param>
        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.StrictTransportSecurity] = "max-age=" +
                _maxAge +
                (_includeSubDomains ? "; includeSubDomains" : string.Empty) +
                (_preload ? "; preload" : string.Empty);

            if (_next != null)
                await _next(context);
        }
    }
}