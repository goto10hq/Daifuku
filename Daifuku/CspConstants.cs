namespace Daifuku
{
    public static class CspConstants
    {
        internal static string NonceHyphenTag = "nonce-";
        internal static string Sha256Tag = "sha256-";
        internal static string Sha384Tag = "sha384-";
        internal static string Sha512Tag = "sha512-";

        /// <summary>
        /// Refers to the origin from which the protected document is being served, including the same URL scheme and port number. You must include the single quotes. Some browsers specifically exclude blob and filesystem from source directives. Sites needing to allow these content types can specify them using the Data attribute. This can be found at Sources.Scheme.*
        /// </summary>
        public const string Self = "'self'";

        /// <summary>
        /// Allows the use of inline resources, such as inline &lt;script&gt; elements, javascript: URLs, inline event handlers, and inline &lt;style&gt; elements. You must include the single quotes.
        /// </summary>
        public const string UnsafeInline = "unsafe-inline";

        /// <summary>
        /// Allows the use of eval() and similar methods for creating code from strings. You must include the single quotes.
        /// </summary>
        public const string UnsafeEval = "unsafe-eval";

        /// <summary>
        /// Refers to the empty set; that is, no URLs match. The single quotes are required.
        /// </summary>
        public const string None = "'none'";

        /// <summary>
        /// The strict-dynamic source expression specifies that the trust explicitly given to a script present in the markup, by accompanying it with a nonce or a hash, shall be propagated to all the scripts loaded by that root script. At the same time, any whitelist or source expressions such as 'self' or 'unsafe-inline' will be ignored.
        /// </summary>
        public const string StrictDynamic = "strict-dynamic";

        /// <summary>
        /// A whitelist for specific inline scripts using a cryptographic nonce (number used once). The server must generate a unique nonce value each time it transmits a policy. It is critical to provide an unguessable nonce, as bypassing a resource’s policy is otherwise trivial. See unsafe inline script for an example.
        /// </summary>
        /// <param name="base64Value"></param>
        /// <returns></returns>
        public static string Nonce(string base64Value) => NonceHyphenTag + base64Value;

        /// <summary>
        /// A sha256, of inline scripts or styles. When generating the hash, don't include the &lt;script;&gt; or &lt;style;&gt; tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha256(string hash) => Sha256Tag + hash;

        /// <summary>
        /// A sha384 of inline scripts or styles. When generating the hash, don't include the &lt;script;&gt; or &lt;style;&gt; tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha384(string hash) => Sha384Tag + hash;

        /// <summary>
        /// A sha512 of inline scripts or styles. When generating the hash, don't include the &lt;script;&gt; or &lt;style;&gt; tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha512(string hash) => Sha512Tag + hash;
    }
}