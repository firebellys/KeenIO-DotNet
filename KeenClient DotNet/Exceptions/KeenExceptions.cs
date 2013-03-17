using System;
using System.Runtime.Serialization;

namespace KeenClient_DotNet.Exceptions
{
    class KeenExceptions
    {
    }
    public class KeenConnectionException : Exception, ISerializable
    {
        public KeenConnectionException()
        {
            // Add implementation.
        }
        public KeenConnectionException(string message)
        {
            // Add implementation.
        }
        public KeenConnectionException(string message, Exception inner)
        {
            // Add implementation.
        }

        // This constructor is needed for serialization.
        protected KeenConnectionException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }
    }

}
