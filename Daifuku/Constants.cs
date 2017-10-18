using System.Collections.Generic;

namespace Daifuku
{
    /// <summary>
    /// Constants.
    /// </summary>
    static class Constants
    {
        /// <summary>
        /// The server header.
        /// </summary>
        internal const string ServerHeader = "Server";

        /// <summary>
        /// X-Powered-By header.
        /// </summary>
        internal const string XPoweredBy = "X-Powered-By";

        /// <summary>
        /// Referrer policy header.
        /// </summary>
        internal const string ReferrerPolicy = "Referrer-Policy";

        /// <summary>
        /// Referrers.
        /// </summary>
        internal static Dictionary<ReferrerPolicy, string> Referrers = new Dictionary<ReferrerPolicy, string>
        {
            { Daifuku.ReferrerPolicy.NoReferrer, "no-referrer" },
            { Daifuku.ReferrerPolicy.NoReferrerWhenDowngrade, "no-referrer-when-downgrade" },
            { Daifuku.ReferrerPolicy.SameOrigin, "same-origin" },
            { Daifuku.ReferrerPolicy.Origin, "origin" },
            { Daifuku.ReferrerPolicy.StrictOrigin, "strict-origin" },
            { Daifuku.ReferrerPolicy.OriginWhenCrossOrigin, "origin-when-cross-origin" },
            { Daifuku.ReferrerPolicy.StrictOriginWhenCrossOrigin, "strict-origin-when-cross-origin" },
            { Daifuku.ReferrerPolicy.UnsafeUrl, "unsafe-url" }
        };
    }
}