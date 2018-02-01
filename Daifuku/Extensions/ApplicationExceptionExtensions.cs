using Daifuku.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Daifuku.Extensions
{
    public static class ApplicationExceptionExtensions
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IApplicationException appException)
        {
            if (modelState == null)
                throw new ArgumentNullException(nameof(modelState));

            if (appException == null)
                throw new ArgumentNullException(nameof(appException));

            if (!string.IsNullOrWhiteSpace(appException.Message))
                modelState.AddModelError(string.Empty, appException.Message);

            if (appException.Messages != null)
            {
                foreach (var m in appException.Messages)
                {
                    modelState.AddModelError(m.Field, m.Message);
                }
            }
        }
    }
}