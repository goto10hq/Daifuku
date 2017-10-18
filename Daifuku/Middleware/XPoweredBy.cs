using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class XPoweredBy
    {
        readonly string _header;
        readonly RequestDelegate _next;

        public XPoweredBy(RequestDelegate next, string header = null)
        {
            _next = next;
            _header = header;
        }

        public async Task Invoke(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(_header))
                context.Response.Headers.Remove(Constants.XPoweredBy);
            else
                context.Response.Headers[Constants.XPoweredBy] = _header;

            if (_next != null)
                await _next(context);
        }
    }
}