﻿using System.Collections.Generic;

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
        /// X powered by header.
        /// </summary>
        internal const string XPoweredBy = "X-Powered-By";

        /// <summary>
        /// Referrer policy header.
        /// </summary>
        internal const string ReferrerPolicy = "Referrer-Policy";

        /// <summary>
        /// X content type options.
        /// </summary>
        internal const string XContentTypeOptions = "X-Content-Type-Options";

        /// <summary>
        /// X frame options.
        /// </summary>
        internal const string FrameGuardHeader = "X-Frame-Options";

        /// <summary>
        /// X content type options value for no sniff.
        /// </summary>
        internal const string NoSniff = "nosniff";

        /// <summary>
        /// XSS protection.
        /// </summary>
        internal const string XssProtection = "X-XSS-Protection";

        /// <summary>
        /// Strict transport secutiry.
        /// </summary>
        internal const string StrictTransportSecurity = "Strict-Transport-Security";

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

        /// <summary>
        /// Frame guards.
        /// </summary>
        internal static Dictionary<FrameGuard, string> FrameGuards = new Dictionary<FrameGuard, string>
        {
            { FrameGuard.Deny, "DENY" },
            { FrameGuard.SameOrigin, "SAMEORIGIN" },
            { FrameGuard.AllowFrom, "ALLOW-FROM" }
        };

        /// <summary>
        /// XSS protections.
        /// </summary>
        internal static Dictionary<XssProtection, string> XssProtections = new Dictionary<XssProtection, string>
        {
            { Daifuku.XssProtection.Disabled, "0" },
            { Daifuku.XssProtection.Enabled, "1" },
            { Daifuku.XssProtection.EnabledWithBlock, "1; mode=block" }
        };
    }
}