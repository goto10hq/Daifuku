namespace Daifuku
{
    /// <summary>
    /// Schemes.
    /// </summary>
    public static class Schemes
    {
        /// <summary>
        /// Allows data: URIs to be used as a content source. This is insecure; an attacker can also inject arbitrary data: URIs. Use this sparingly and definitely not for scripts.
        /// </summary>
        public const string Data = "data:";

        /// <summary>
        /// Allows mediastream: URIs to be used as a content source.
        /// </summary>
        public const string MediaStream = "mediastream:";

        /// <summary>
        /// Allows blob: URIs to be used as a content source.
        /// </summary>
        public const string Blob = "blob:";

        /// <summary>
        /// Allows filesystem: URIs to be used as a content source.
        /// </summary>
        public const string FileSystem = "filesystem:";

        /// <summary>
        /// Http protocol prefix.
        /// </summary>
        public const string Http = "http:";

        /// <summary>
        /// Http protocol prefix.
        /// </summary>
        public const string Https = "https:";
    }
}