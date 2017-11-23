using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Daifuku.Validations
{
    public class ValidationResultModel
    {
        [JsonProperty("message")]
        public string Message { get; }

        [JsonProperty("errors")]
        public List<ValidationError> Errors { get; }

        public ValidationResultModel(string message, List<ValidationError> errors)
        {
            Message = message;
            Errors = errors;
        }

        public ValidationResultModel(string message, ModelStateDictionary modelState)
        {
            Message = message;
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}