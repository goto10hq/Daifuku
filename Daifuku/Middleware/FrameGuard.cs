using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class FrameGuard
    {
        readonly FrameGuardOptions _options;
        readonly RequestDelegate _next;

        public FrameGuard(RequestDelegate next, FrameGuardOptions options)
        {
            _next = next;
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Invoke the specified context.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="context">Context.</param>
        public async Task Invoke(HttpContext context)
        {
            if (_options.Guard == Daifuku.FrameGuard.Deny ||
                _options.Guard == Daifuku.FrameGuard.SameOrigin)
                context.Response.Headers[Constants.FrameGuardHeader] = Constants.FrameGuards[_options.Guard];
            else
                context.Response.Headers[Constants.FrameGuardHeader] = Constants.FrameGuards[_options.Guard] + " " + _options.Domain;

            if (_next != null)
                await _next(context);
        }
    }
}