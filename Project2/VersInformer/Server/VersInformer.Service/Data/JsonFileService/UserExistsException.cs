using System;
using System.Runtime.Serialization;

namespace VersInformer.Service.Data.JsonFileService
{
    /// <summary>
    /// User Exists Exception
    /// </summary>
    public class UserExistsException : ApplicationException
    {
        /// <summary>
        /// The _user name
        /// </summary>
        private readonly string _userName;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserExistsException"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public UserExistsException(string userName)
        {
            _userName = userName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserExistsException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="userName">Name of the user.</param>
        public UserExistsException(string message, string userName) : base(message)
        {
            _userName = userName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserExistsException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="userName">Name of the user.</param>
        public UserExistsException(string message, Exception innerException, string userName) : base(message, innerException)
        {
            _userName = userName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserExistsException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        /// <param name="userName">Name of the user.</param>
        protected UserExistsException(SerializationInfo info, StreamingContext context, string userName) : base(info, context)
        {
            _userName = userName;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get { return _userName; }
        }
    }
}