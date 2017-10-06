using Daifuku.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;

namespace Daifuku.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseDomainEnforcement(this IApplicationBuilder app, Dictionary<string, string> domainRedirects)
        {
            if (app == null)            
                throw new ArgumentNullException(nameof(app));
            
            return app.UseMiddleware<EnforceDomain>(domainRedirects);
        }

        public static IApplicationBuilder UseServerHeader(this IApplicationBuilder app, string header = null)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ServerHeader>(header);
        }
    }
}
