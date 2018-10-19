using Daifuku.Extensions;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;

namespace Daifuku.Attributes
{
    /// <summary>
    /// Action attribute for forcing ajax requests only.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        readonly bool _extendedCheck = true;

        /// <summary>
        /// Ctor.
        /// </summary>
        public AjaxOnlyAttribute()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="extendedCheck">Extended check flag.</param>
        public AjaxOnlyAttribute(bool extendedCheck)
        {
            _extendedCheck = extendedCheck;
        }

        /// <summary>
        /// Is valid for request flag.
        /// </summary>
        /// <param name="routeContext">Route context.</param>
        /// <param name="action">Action descriptor.</param>
        /// <returns>Flag.</returns>
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest(_extendedCheck);
        }
    }
}