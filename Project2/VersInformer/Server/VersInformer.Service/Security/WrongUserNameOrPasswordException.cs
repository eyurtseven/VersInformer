using System;
using System.Runtime.Serialization;

namespace VersInformer.Service.Security
{
    public class WrongUserNameOrPasswordException : ApplicationException
    {
        public String UserName { get; private set; }
        public WrongUserNameOrPasswordException()
        {
        }


        public WrongUserNameOrPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected WrongUserNameOrPasswordException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public WrongUserNameOrPasswordException(string userName, string message, Exception innerException) : base(message, innerException)
        {
            UserName = userName;
        }

        protected WrongUserNameOrPasswordException(string userName, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            UserName = userName;
        }

        public WrongUserNameOrPasswordException(string userName, string message) : base(message)
        {
            UserName = userName;
        }

    }
}