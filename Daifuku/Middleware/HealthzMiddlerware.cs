using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    class HealthzMiddleware
    {
        readonly RequestDelegate _next;

        public HealthzMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Headers.Add("Cache-Control", "no-cache, no-store");

            await context.Response.WriteAsync(string.Empty).ConfigureAwait(false);
        }
    }
}