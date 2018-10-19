using System;
using System.Text;

namespace Daifuku.Builders
{
    static class ContentSecurityPolicyBuilder
    {
        internal static string Build(ContentSecurityPolicy policy)
        {
            var stringBuilder = new StringBuilder();

            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            if (policy.DefaultSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.DefaultSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.DefaultSrc)).Append("; ");
            }

            if (policy.ScriptSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ScriptSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.ScriptSrc)).Append("; ");
            }

            if (policy.StyleSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.StyleSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.StyleSrc)).Append("; ");
            }

            if (policy.ImgSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ImgSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.ImgSrc)).Append("; ");
            }

            if (policy.ConnectSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ConnectSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.ConnectSrc)).Append("; ");
            }

            if (policy.FontSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.FontSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.FontSrc)).Append("; ");
            }

            if (policy.ObjectSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ObjectSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.ObjectSrc)).Append("; ");
            }

            if (policy.MediaSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.MediaSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.MediaSrc)).Append("; ");
            }

            if (policy.ChildSrc?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ChildSrc);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.ChildSrc)).Append("; ");
            }

            if (policy.FormAction?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.FormAction);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.FormAction)).Append("; ");
            }

            if (policy.FrameAncestors?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.FrameAncestors);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.FrameAncestors)).Append("; ");
            }

            if (policy.Sandbox != null)
            {
                stringBuilder.Append(Constants.CspDirectives.Sandbox);
                stringBuilder.Append(" ").Append(policy.Sandbox.Value).Append("; ");
            }

            if (policy.PluginTypes?.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.PluginTypes);
                stringBuilder.Append(" ").Append(string.Join(" ", policy.PluginTypes)).Append("; ");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}