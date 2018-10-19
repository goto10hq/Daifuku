using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class FeaturePolicy
    {
        readonly RequestDelegate _next;
        readonly string _policy;

        public FeaturePolicy(RequestDelegate next, Daifuku.FeaturePolicy policy)
        {
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            _policy = Builders.FeaturePolicyBuilder.Build(policy);
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.FeaturePolicy] = _policy;

            if (_next != null)
                await _next(context).ConfigureAwait(false);
        }
    }
}