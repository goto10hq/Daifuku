using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class EnforceDomainMiddleware
    {
        readonly RequestDelegate _next;
        Dictionary<string, string> _domainRedirects;

        public EnforceDomainMiddleware(RequestDelegate next, Dictionary<string, string> domainRedirects)
        {
            _domainRedirects = domainRedirects;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpRequest req = context.Request;

            var host = req.Host.Host.ToLower();
            var redirect = _domainRedirects.FirstOrDefault(dr => dr.Key.Equals(host, StringComparison.OrdinalIgnoreCase));
            
            if (redirect.Value != null)
            {                
                var url = req.Scheme + "://" + redirect.Value + req.Path + req.QueryString;
                context.Response.Redirect(url, true);                
            }
            else            
            {
                await _next(context);
            }
        }
    }
}
