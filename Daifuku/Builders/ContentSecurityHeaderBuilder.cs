using System;
using System.Text;

namespace Daifuku.Builders
{
    internal class ContentSecurityPolicyBuilder
    {
        internal static string Build(ContentSecurityPolicy policy)
        {
            var stringBuilder = new StringBuilder();

            if (policy == null)
                throw new ArgumentNullException(nameof(policy));

            if (policy.DefaultSrc != null && policy.DefaultSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.DefaultSrc);
                stringBuilder.Append($" {string.Join(" ", policy.DefaultSrc)}; ");
            }

            if (policy.ScriptSrc != null && policy.ScriptSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ScriptSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ScriptSrc)}; ");
            }

            if (policy.StyleSrc != null && policy.StyleSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.StyleSrc);
                stringBuilder.Append($" {string.Join(" ", policy.StyleSrc)}; ");
            }

            if (policy.ImgSrc != null && policy.ImgSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ImgSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ImgSrc)}; ");
            }

            if (policy.ConnectSrc != null && policy.ConnectSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ConnectSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ConnectSrc)}; ");
            }

            if (policy.FontSrc != null && policy.FontSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.FontSrc);
                stringBuilder.Append($" {string.Join(" ", policy.FontSrc)}; ");
            }

            if (policy.ObjectSrc != null && policy.ObjectSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ObjectSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ObjectSrc)}; ");
            }

            if (policy.MediaSrc != null && policy.MediaSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.MediaSrc);
                stringBuilder.Append($" {string.Join(" ", policy.MediaSrc)}; ");
            }

            if (policy.ChildSrc != null && policy.ChildSrc.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.ChildSrc);
                stringBuilder.Append($" {string.Join(" ", policy.ChildSrc)}; ");
            }

            if (policy.FormAction != null && policy.FormAction.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.FormAction);
                stringBuilder.Append($" {string.Join(" ", policy.FormAction)}; ");
            }

            if (policy.FrameAncestors != null && policy.FrameAncestors.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.FrameAncestors);
                stringBuilder.Append($" {string.Join(" ", policy.FrameAncestors)}; ");
            }

            if (policy.Sandbox != null)
            {
                stringBuilder.Append(Constants.CspDirectives.Sandbox);
                stringBuilder.Append($" {policy.Sandbox.Value}; ");
            }

            if (policy.PluginTypes != null && policy.PluginTypes.Count > 0)
            {
                stringBuilder.Append(Constants.CspDirectives.PluginTypes);
                stringBuilder.Append($" {string.Join(" ", policy.PluginTypes)}; ");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}