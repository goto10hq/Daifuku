using Newtonsoft.Json;

namespace Daifuku.Validations
{
    public class ValidationError
    {
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        [JsonProperty("message")]
        public string Message { get; }

        public ValidationError(string message)
        {
            Message = message;
        }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }

        public static implicit operator ValidationError(string message)
        {
            return new ValidationError(string.Empty, message);
        }
    }
}