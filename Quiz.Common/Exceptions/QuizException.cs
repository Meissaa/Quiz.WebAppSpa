using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Exceptions
{
    [Serializable]
    public class QuizException : Exception
    {
        public QuizException() { }
        public QuizException(string message) : base(message) { }
        public QuizException(string message, Exception inner) : base(message, inner) { }
        protected QuizException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
