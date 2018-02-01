using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Daifuku.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request, bool extendedCheck = true)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var r = request.Headers["Accept"].ToString();

            if (request.Headers != null &&
                request.Headers["X-Requested-With"].Any(h => h.Equals("XMLHttpRequest", StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            if (!extendedCheck)
                return false;

            if (request.Headers != null &&
                request.Headers["Accept"].Any(h => h.IndexOf("application/json", StringComparison.OrdinalIgnoreCase) >= 0))
            {
                return true;
            }

            return false;
        }
    }
}