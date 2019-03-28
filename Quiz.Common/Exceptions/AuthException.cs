using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Exceptions
{
    [Serializable]
    public class AuthException : Exception
    {

        public AuthException() { }
        public AuthException(string message) : base(message) { }
        public AuthException(string message, Exception inner) : base(message, inner) { }
        protected AuthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
