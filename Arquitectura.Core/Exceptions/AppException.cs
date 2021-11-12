using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Arquitectura.Core.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(object args)
            : base((string)args)
        {
        }
    }
}
