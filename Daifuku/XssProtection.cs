namespace Daifuku
{
    /// <summary>
    /// XSS protections.
    /// </summary>
    public enum XssProtection
    {
        /// <summary>
        /// Disables XSS filtering.
        /// </summary>
        Disabled,

        /// <summary>
        /// Enables XSS filtering (usually default in browsers). If a cross-site scripting attack is detected,
        /// the browser will sanitize the page (remove the unsafe parts).
        /// </summary>
        Enabled,

        /// <summary>
        /// Enables XSS filtering. Rather than sanitizing the page, the browser will prevent rendering of the page if an attack is detected.
        /// </summary>
        EnabledWithBlock,
    }
}