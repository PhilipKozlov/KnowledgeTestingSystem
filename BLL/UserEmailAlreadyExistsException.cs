using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// The exception that is thrown when user with specified email already exists.
    /// </summary>
    public class UserEmailAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of UserEmailAlreadyExistsException class.
        /// </summary>
        public UserEmailAlreadyExistsException() { }
        /// <summary>
        /// Initializes a new instance of UserEmailAlreadyExistsException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        public UserEmailAlreadyExistsException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of UserEmailAlreadyExistsException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        /// <param name="innerException"> The exception that is the cause of the current exception. If the innerException
        ///  parameter is not a null reference, the current exception is raised in a catch
        ///  block that handles the inner exception.</param>
        public UserEmailAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
