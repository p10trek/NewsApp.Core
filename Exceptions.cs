using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core
{
    [Serializable]
    public class CustomException : Exception
    {
        public string MethodName { get; }

        public CustomException() { }

        public CustomException(string message)
            : base(message) { }

        public CustomException(string message, Exception inner)
            : base(message, inner) { }

        public CustomException(string message, string methodName)
            : this(message)
        {
           MethodName = methodName;
        }
    }
}
