using Daifuku.Extensions;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;

namespace Daifuku.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        readonly bool _extendedCheck = true;

        public AjaxOnlyAttribute()
        {
        }

        public AjaxOnlyAttribute(bool extendedCheck)
        {
            _extendedCheck = extendedCheck;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest(_extendedCheck);
        }
    }
}