using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// The exception that is thrown when role already exists.
    /// </summary>
    public class RoleAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of RoleAlreadyExistsException class.
        /// </summary>
        public RoleAlreadyExistsException() { }
        /// <summary>
        /// Initializes a new instance of RoleAlreadyExistsException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        public RoleAlreadyExistsException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of RoleAlreadyExistsException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        /// <param name="innerException"> The exception that is the cause of the current exception. If the innerException
        ///  parameter is not a null reference, the current exception is raised in a catch
        ///  block that handles the inner exception.</param>
        public RoleAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
