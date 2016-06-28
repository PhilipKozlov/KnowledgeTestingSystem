using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// The exception that is thrown when the process can`t access reequired data.
    /// </summary>
    public class DataAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of DataAccessException class.
        /// </summary>
        public DataAccessException() { }
        /// <summary>
        /// Initializes a new instance of DataAccessException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        public DataAccessException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of DataAccessException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        /// <param name="innerException"> The exception that is the cause of the current exception. If the innerException
        ///  parameter is not a null reference, the current exception is raised in a catch
        ///  block that handles the inner exception.</param>
        public DataAccessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
