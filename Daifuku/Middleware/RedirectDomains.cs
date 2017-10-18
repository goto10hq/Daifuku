using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    /// <summary>
    /// Enforce domain.
    /// </summary>
    public class RedirectDomains
    {
        readonly RequestDelegate _next;
        Dictionary<string, string> _domainRedirects;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Daifuku.Middleware.EnforceDomain"/> class.
        /// </summary>
        /// <param name="next">Next.</param>
        /// <param name="domainRedirects">Domain redirects.</param>
        public RedirectDomains(RequestDelegate next, Dictionary<string, string> domainRedirects)
        {
            _domainRedirects = domainRedirects;
            _next = next;
        }

        /// <summary>
        /// Invoke the specified context.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="context">Context.</param>
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
                if (_next != null)
                    await _next(context);
            }
        }
    }
}
