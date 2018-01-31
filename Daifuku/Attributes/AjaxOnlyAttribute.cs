using Daifuku.Extensions;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace Daifuku.Attributes
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        readonly bool _fuzzy = true;

        public AjaxOnlyAttribute()
        {
        }

        public AjaxOnlyAttribute(bool fuzzy)
        {
            _fuzzy = fuzzy;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest(_fuzzy);
        }
    }
}