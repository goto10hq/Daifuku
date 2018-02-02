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

            var messagesUsed = false;

            if (appException.Messages != null)
            {
                foreach (var m in appException.Messages)
                {
                    messagesUsed = true;
                    modelState.AddModelError(m.Field ?? string.Empty, m.Message);
                }
            }

            var messageUsed = false;

            if (!string.IsNullOrWhiteSpace(appException.Message))
            {
                messageUsed = true;
                modelState.AddModelError(string.Empty, appException.Message);
            }

            if (!messagesUsed &&
                !messageUsed)
            {
                modelState.AddModelError(string.Empty, "Internal error");
            }
        }
    }
}