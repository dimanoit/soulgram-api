using System.Collections.Generic;

namespace Soulgram.Model
{
    public class ValidationError
    {
        public ValidationError(string propertyName, IEnumerable<string> errorMessages)
        {
            PropertyName = propertyName;
            ErrorMessages = errorMessages;
        }

        public string PropertyName { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
