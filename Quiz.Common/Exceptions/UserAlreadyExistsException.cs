using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Quiz.Common.Exceptions
{
    [Serializable]
    public class UserAlreadyExistsException: Exception
    {
        public UserAlreadyExistsException() { }
        public UserAlreadyExistsException(string message) : base(message) { }
        public UserAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
        protected UserAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
