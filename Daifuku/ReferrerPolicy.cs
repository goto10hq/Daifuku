namespace Daifuku
{
    /// <summary>
    /// Referrer policies.
    /// </summary>
    public enum ReferrerPolicy
    {
        /// <summary>
        /// The empty string "" corresponds to no referrer policy, causing a fallback to a referrer policy defined elsewhere,
        /// or in the case where no such higher-level policy is available, defaulting to "no-referrer-when-downgrade".
        /// </summary>
        Empty,

        /// <summary>
        /// The simplest policy is "no-referrer", which specifies that no referrer information is to be sent along with requests
        /// made from a particular request client to any origin. The header will be omitted entirely.
        /// </summary>
        NoReferrer,

        /// <summary>
        /// The "no-referrer-when-downgrade" policy sends a full URL along with requests from a TLS-protected environment
        /// settings object to a potentially trustworthy URL, and requests from clients which are not TLS-protected to any origin.
        /// Requests from TLS-protected clients to non- potentially trustworthy URLs, on the other hand, will contain no referrer
        /// information.A Referer HTTP header will not be sent.
        /// </summary>
        NoReferrerWhenDowngrade,

        /// <summary>
        /// The "same-origin" policy specifies that a full URL, stripped for use as a referrer, is sent as referrer information
        /// when making same-origin requests from a particular client.
        /// Cross-origin requests, on the other hand, will contain no referrer information.A Referer HTTP header will not be sent.
        /// </summary>
        SameOrigin,

        /// <summary>
        /// The "origin" policy specifies that only the ASCII serialization of the origin of the request client is sent as referrer
        /// information when making both same-origin requests and cross-origin requests from a particular client.
        /// </summary>
        Origin,

        /// <summary>
        /// The "strict-origin" policy sends the ASCII serialization of the origin of the request client when making requests:
        /// from a TLS-protected environment settings object to a potentially trustworthy URL, and from non-TLS-protected environment settings objects to any origin.
        /// Requests from TLS-protected request clients to non- potentially trustworthy URLs, on the other hand, will contain no referrer information.
        /// A Referer HTTP header will not be sent.
        /// </summary>
        StrictOrigin,

        /// <summary>
        /// The "origin-when-cross-origin" policy specifies that a full URL, stripped for use as a referrer, is sent as referrer
        /// information when making same-origin requests from a particular request client, and only the ASCII serialization of the origin
        /// of the request client is sent as referrer information when making cross-origin requests from a particular client.
        /// </summary>
        OriginWhenCrossOrigin,

        /// <summary>
        /// The "strict-origin-when-cross-origin" policy specifies that a full URL, stripped for use as a referrer, is sent as referrer
        /// information when making same-origin requests from a particular request client, and only the ASCII serialization of the origin
        /// of the request client when making cross-origin requests: from a TLS-protected environment settings object to a potentially
        /// trustworthy URL, and from non-TLS-protected environment settings objects to any origin.
        /// </summary>
        StrictOriginWhenCrossOrigin,

        /// <summary>
        /// The "unsafe-url" policy specifies that a full URL, stripped for use as a referrer, is sent along with both cross-origin
        /// requests and same-origin requests made from a particular client.
        /// </summary>
        UnsafeUrl
    }
}