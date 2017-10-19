using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    /// <summary>
    /// Server header.
    /// </summary>
    public class ServerHeader
    {
        readonly string _header;
        readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Daifuku.Middleware.ServerHeader"/> class.
        /// </summary>
        /// <param name="next">Next.</param>
        /// <param name="header">Server header.</param>
        public ServerHeader(RequestDelegate next, string header = null)
        {
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
            if (string.IsNullOrWhiteSpace(_header))
                context.Response.Headers.Remove(Constants.ServerHeader);
            else
                context.Response.Headers[Constants.ServerHeader] = _header ?? string.Empty;

            if (_next != null)
                await _next(context);
        }
    }
}