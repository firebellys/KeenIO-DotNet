using System;
using System.Runtime.Serialization;

namespace KeenClient_DotNet.Exceptions
{
    class KeenExceptions
    {
    }
    [Serializable]
    public class KeenBaseException : Exception
    {
        public string ReturnMessage { get; set; }
        public KeenBaseException()
        {

        }
        public KeenBaseException(string message, string errorcode)
            : base(errorcode)
        {
            ReturnMessage = message;
        }
    }

}
