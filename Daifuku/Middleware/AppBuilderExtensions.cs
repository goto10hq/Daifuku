using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;

namespace Daifuku.Middleware
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseDomainEnforcement(this IApplicationBuilder app, Dictionary<string, string> domainRedirects)
        {
            if (app == null)            
                throw new ArgumentNullException(nameof(app));
            
            return app.UseMiddleware<EnforceDomainMiddleware>(domainRedirects);
        }
    }
}
