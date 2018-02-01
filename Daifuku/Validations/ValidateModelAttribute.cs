using Daifuku.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Daifuku.Validations
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }
        public string View { get; set; }

        public ValidateModelAttribute(string message = "", string view = null)
        {
            Message = message;
            View = view;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ModelState.IsValid &&
                context.HttpContext.Request.IsAjaxRequest())
            {
                context.Result = new ValidationFailedResult(Message, context.ModelState);
            }
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid &&
                context.HttpContext.Request.IsAjaxRequest())
            {
                context.Result = new ValidationFailedResult(Message, context.ModelState);
            }
        }
    }
}