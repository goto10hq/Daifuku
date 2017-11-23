using Microsoft.AspNetCore.Mvc.Filters;

namespace Daifuku.Validations
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public ValidateModelAttribute(string message)
        {
            Message = message;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(Message, context.ModelState);
            }
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(Message, context.ModelState);
            }
        }
    }
}