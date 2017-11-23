using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Daifuku.Validations
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(string message, ModelStateDictionary modelState)
            : base(new ValidationResultModel(message, modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}