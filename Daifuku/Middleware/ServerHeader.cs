using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class ServerHeader
    {
        readonly string _header;
        readonly RequestDelegate _next;

        public ServerHeader(RequestDelegate next, string header = null)
        {
            _next = next;
            _header = header;
        }

        public async Task Invoke(HttpContext context)
        {            
            if (string.IsNullOrWhiteSpace(_header))            
                context.Response.Headers.Remove(Constants.ServerHeader);            
            else            
                context.Response.Headers[Constants.ServerHeader] = _header;            

            if (_next != null)
                await _next(context);
        }
    }
}
