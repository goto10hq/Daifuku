using System;

namespace Daifuku
{
    public enum FrameGuard
    {
        AllowFrom,
        Deny,
        SameOrigin
    }

    public class FrameGuardOptions
    {
        internal readonly string Domain;
        internal readonly FrameGuard Guard;

        public FrameGuardOptions(FrameGuard guard)
        {
            if (guard == FrameGuard.AllowFrom)
                throw new ArgumentException($"Frame guard {guard} is only allowed with a domain set.");

            Guard = guard;
            Domain = string.Empty;
        }

        public FrameGuardOptions(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain))
                throw new ArgumentNullException(nameof(domain));

            Guard = FrameGuard.AllowFrom;
            Domain = domain;
        }
    }
}