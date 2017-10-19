using System;

namespace Daifuku
{
    public class ContentSecurityPolicyBuilder
    {
        internal readonly ContentSecurityPolicy Policy = new ContentSecurityPolicy();

        public ContentSecurityPolicyBuilder WithDefaultSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
                throw new ArgumentException(nameof(sources));

            Policy.DefaultSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithScriptSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.ScriptSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithStyleSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.StyleSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithImageSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.ImgSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithConnectSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.ConnectSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithFontSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.FontSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithObjectSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.ObjectSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithMediaSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.MediaSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithChildSource(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.ChildSrc.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithFormAction(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.FormAction.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithFrameAncestors(params string[] sources)
        {
            if (sources == null || sources.Length < 1)
            {
                throw new ArgumentException(nameof(sources));
            }
            Policy.FrameAncestors.UnionWith(sources);
            return this;
        }

        public ContentSecurityPolicyBuilder WithPluginTypes(params string[] mimeTypes)
        {
            if (mimeTypes == null || mimeTypes.Length < 1)
            {
                throw new ArgumentException(nameof(mimeTypes));
            }
            Policy.PluginTypes.UnionWith(mimeTypes);
            return this;
        }

        public ContentSecurityPolicyBuilder WithSandBox(BaseSandboxOptions sandboxOption)
        {
            Policy.Sandbox = sandboxOption ?? throw new ArgumentNullException(nameof(sandboxOption));
            return this;
        }

        public ContentSecurityPolicy BuildPolicy() => Policy;
    }
}