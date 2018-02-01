using Daifuku.Extensions;
using Daifuku.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Daifuku.Exceptions
{
    public sealed class ApplicationExceptionFilter<T> : IExceptionFilter where T : IApplicationException
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();

            if (context.Exception is IApplicationException appException)
            {
                var modelState = context.ModelState;

                if (appException.Messages != null &&
                    appException.Messages.Any())
                {
                    foreach (var m in appException.Messages)
                        modelState.AddModelError(m.Field ?? "", m.Message);
                }
                else if (!string.IsNullOrEmpty(appException.Message))
                {
                    modelState.AddModelError("", appException.Message);
                }
                else
                    modelState.AddModelError("", "Internal error.");

                var title = string.Empty;

                var validateModelFilter = context.Filters.FirstOrDefault(f => f.GetType() == typeof(ValidateModelAttribute));

                if (validateModelFilter != null &&
                    validateModelFilter is ValidateModelAttribute vma)
                    title = vma.Message;

                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    context.Result = new ValidationFailedResult(title, context.ModelState);
                }
                else
                {
                    context.Exception = null;
                    context.ExceptionHandled = true;

                    var viewName = context.RouteData.Values["action"] as string;

                    if (validateModelFilter != null &&
                        validateModelFilter is ValidateModelAttribute vma2)
                    {
                        if (!string.IsNullOrEmpty(vma2.View))
                            viewName = vma2.View;
                    }

                    context.Result = new ViewResult
                    {
                        ViewName = viewName
                    };
                }
            }
        }
    }
}