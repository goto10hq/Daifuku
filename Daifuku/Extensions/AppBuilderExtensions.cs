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
        /// Redirect domains.
        /// </summary>
        /// <returns>Pipeline.</returns>
        /// <param name="app">App.</param>
        /// <param name="domainRedirects">Domain redirects.</param>
        public static IApplicationBuilder RedirectDomains(this IApplicationBuilder app, Dictionary<string, string> domainRedirects)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<RedirectDomains>(domainRedirects);
        }

        /// <summary>
        /// Uses the server header or remove.
        /// </summary>
        /// <returns>Pipeline.</returns>
        /// <param name="app">App.</param>
        /// <param name="header">Server header. If set to <c>null</c> just remove server header completely.</param>
        public static IApplicationBuilder UseServerHeader(this IApplicationBuilder app, string header = "")
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ServerHeader>(header);
        }

        public static IApplicationBuilder UseNoMimeSniff(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<NoSniff>();
        }

        public static IApplicationBuilder UseReferrerPolicy(this IApplicationBuilder app, ReferrerPolicy policy)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<Middleware.ReferrerPolicy>(policy);
        }

        public static IApplicationBuilder UsePoweredBy(this IApplicationBuilder app, string header = "")
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<XPoweredBy>(header);
        }

        public static IApplicationBuilder UseFrameGuard(this IApplicationBuilder app, FrameGuardOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<Middleware.FrameGuard>(options);
        }

        public static IApplicationBuilder UseXssProtection(this IApplicationBuilder app, XssProtection protection)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<Middleware.XssProtection>(protection);
        }

        public static IApplicationBuilder UseHsts(this IApplicationBuilder app, ulong maxAge = 31536000, bool includeSubDomains = false, bool preload = false)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<Hsts>(maxAge, includeSubDomains, preload);
        }

        public static IApplicationBuilder UseCustomHeader(this IApplicationBuilder app, string header, string value)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<CustomHeader>(header, value);
        }

        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder app, ContentSecurityPolicy policy)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<Middleware.ContentSecurityPolicy>(policy);
        }

        public static IApplicationBuilder UseFeaturePolicy(this IApplicationBuilder app, FeaturePolicy policy)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<Middleware.FeaturePolicy>(policy);
        }

        public static IApplicationBuilder UseExpectCt(this IApplicationBuilder app, ulong maxAge, string reportUri, bool enforce = false)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ExpectCt>(maxAge, reportUri, enforce);
        }

        public static IApplicationBuilder UseDaifuku(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ServerHeader>("")
                .UseMiddleware<Middleware.FrameGuard>(new FrameGuardOptions(FrameGuard.SameOrigin))
                .UseMiddleware<Middleware.XssProtection>(XssProtection.EnabledWithBlock)
                .UseMiddleware<NoSniff>(true)
                .UseMiddleware<Middleware.ReferrerPolicy>(ReferrerPolicy.NoReferrer)
                .UseMiddleware<XPoweredBy>("");
        }

        public static IApplicationBuilder UseHealthz(this IApplicationBuilder app, string path = "/healthz")
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return app.Map(path, appBuilder => appBuilder.UseMiddleware<HealthzMiddleware>());
        }
    }
}