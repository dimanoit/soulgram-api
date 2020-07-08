using Soulgram.Model;
using System;
using System.Collections.Generic;

namespace Soulgram.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public ValidationFailedException(string message, IEnumerable<ValidationError> errors)
            : base(message)
        {
            ErrorList = errors;
        }

        public IEnumerable<ValidationError> ErrorList { get; set; }
    }
}
