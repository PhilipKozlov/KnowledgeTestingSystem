using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Logger
{
    /// <summary>
    /// Represents common logging functionality.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        void Trace(string message);
        /// <summary>
        /// Writes the exception at the Trace level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        void Trace(Exception e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Trace level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        void Trace(string message, Exception e);
        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        void Debug(string message);
        /// <summary>
        /// Writes exception at the Trace level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        void Debug(Exception e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Debug level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        void Debug(string message, Exception e);
        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        void Info(string message);
        /// <summary>
        /// Writes exception at the Info level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        void Info(Exception e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Info level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        void Info(string message, Exception e);
        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        void Warn(string message);
        /// <summary>
        /// Writes exception at the Warn level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        void Warn(Exception e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Warn level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        void Warn(string message, Exception e);
        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        void Error(string message);
        /// <summary>
        /// Writes exception at the Error level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        void Error(Exception e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Error level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        void Error(string message, Exception e);
    }
}
