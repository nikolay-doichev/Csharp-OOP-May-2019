using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Exceptions
{
    public class InvalidLayoutException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Layout Type!";
        public InvalidLayoutException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidLayoutException(string message) : base(message)
        {

        }
    }
}
