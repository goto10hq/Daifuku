using Daifuku.Builders;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class ContentSecurityPolicy
    {
        readonly RequestDelegate _next;
        readonly string _policy;

        public ContentSecurityPolicy(RequestDelegate next, Daifuku.ContentSecurityPolicy policy)
        {
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            _policy = Builders.ContentSecurityPolicyBuilder.Build(policy);
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ContentSecurityPolicy] = _policy;

            if (_next != null)
                await _next(context).ConfigureAwait(false);
        }
    }
}