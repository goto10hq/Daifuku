using Microsoft.AspNetCore.Http;
using System;

namespace Daifuku.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request, bool fuzzy = true)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null &&
                request.Headers["X-Requested-With"].ToString().Equals("XMLHttpRequest", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!fuzzy)
                return false;

            if (request.ContentType.IndexOf("application/json", StringComparison.OrdinalIgnoreCase) >= 0 &&
                request.Headers != null &&
                request.Headers["Accept"].ToString().IndexOf("application/json", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}