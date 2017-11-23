using Daifuku.Validations;
using System.Collections.Generic;

namespace Daifuku.Exceptions
{
    public interface IApplicationException
    {
        IEnumerable<ValidationError> Messages { get; }
        string Message { get; }
    }
}