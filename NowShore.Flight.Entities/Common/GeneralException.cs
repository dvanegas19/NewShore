using System;
using System.Collections.Generic;
using System.Text;

namespace NewShore.Fligth.Entities.Common
{   
    public class GeneralException: Exception
    {
        public string Detail { get; set; }

        public GeneralException() { }

        public GeneralException(string message): base(message) { }

        public GeneralException(string message, Exception innerException):
            base(message, innerException)
            { }

        public GeneralException(string title, string detail) :
            base(title) => Detail = detail;


    }
}
