using Daifuku.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;

namespace Daifuku.Extensions
{
    /// <summary>
    /// App builder extensions.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Uses the domain enforcement.
        /// </summary>
        /// <returns>Pipeline.</returns>
        /// <param name="app">App.</param>
        /// <param name="domainRedirects">Domain redirects.</param>
        public static IApplicationBuilder UseDomainEnforcement(this IApplicationBuilder app, Dictionary<string, string> domainRedirects)
        {
            if (app == null)            
                throw new ArgumentNullException(nameof(app));
            
            return app.UseMiddleware<EnforceDomain>(domainRedirects);
        }

        /// <summary>
        /// Uses the server header or remove.
        /// </summary>
        /// <returns>Pipeline..</returns>
        /// <param name="app">App.</param>
        /// <param name="header">Server header. If set to <c>null</c> just remove server header completely.</param>
        public static IApplicationBuilder UseServerHeader(this IApplicationBuilder app, string header = null)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ServerHeader>(header);
        }
    }
}
