using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Todo.Application.Common.Exceptions
{
    public class DateInThePastException : Exception
    {
        public DateInThePastException()
        {
        }

        public DateInThePastException(string? message) : base(message)
        {

        }

        public DateInThePastException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DateInThePastException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
