using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class XPoweredByHeader
    {
        readonly string _header;
        readonly RequestDelegate _next;

        public XPoweredByHeader(RequestDelegate next, string header = null)
        {
            _next = next;
            _header = header;
        }

        public async Task Invoke(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(_header))
            {
                if (context.Response.Headers.ContainsKey(Constants.XPoweredBy))
                    context.Response.Headers.Remove(Constants.XPoweredBy);
            }
            else
            {
                if (context.Response.Headers.ContainsKey(Constants.XPoweredBy))
                    context.Response.Headers[Constants.XPoweredBy] = _header;
                else
                    context.Response.Headers.Add(Constants.XPoweredBy, _header);
            }

            if (_next != null)
                await _next(context);
        }
    }
}