using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Daifuku.Middleware
{
    public class ReferrerPolicy
    {
        readonly RequestDelegate _next;
        readonly Daifuku.ReferrerPolicy _policy;

        public ReferrerPolicy(RequestDelegate next, Daifuku.ReferrerPolicy policy)
        {
            _policy = policy;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ReferrerPolicy] = Constants.Referrers[_policy];

            if (_next != null)
                await _next(context).ConfigureAwait(false);
        }
    }
}