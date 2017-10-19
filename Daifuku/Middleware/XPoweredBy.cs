using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class XPoweredBy
    {
        readonly string _header;
        readonly RequestDelegate _next;

        public XPoweredBy(RequestDelegate next, string header)
        {
            _next = next;
            _header = header;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.XPoweredBy] = _header ?? string.Empty;

            if (_next != null)
                await _next(context);
        }
    }
}