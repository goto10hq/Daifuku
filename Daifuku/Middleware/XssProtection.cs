using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class XssProtection
    {
        readonly RequestDelegate _next;
        readonly Daifuku.XssProtection _protection;

        public XssProtection(RequestDelegate next, Daifuku.XssProtection protection)
        {
            _protection = protection;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.XssProtection] = Constants.XssProtections[_protection];

            if (_next != null)
                await _next(context);
        }
    }
}