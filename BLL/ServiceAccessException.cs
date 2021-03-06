﻿using System;

namespace BLL
{
    /// <summary>
    /// The exception that is thrown when the process can`t access required service.
    /// </summary>
    public class ServiceAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of ServiceAccessException class.
        /// </summary>
        public ServiceAccessException() { }
        /// <summary>
        /// Initializes a new instance of ServiceAccessException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        public ServiceAccessException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of ServiceAccessException class with specified parameters.
        /// </summary>
        /// <param name="message"> The error message that explains the reason for the exception.</param>
        /// <param name="innerException"> The exception that is the cause of the current exception. If the innerException
        ///  parameter is not a null reference, the current exception is raised in a catch
        ///  block that handles the inner exception.</param>
        public ServiceAccessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
