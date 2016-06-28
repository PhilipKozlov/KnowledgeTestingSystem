using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /// <summary>
    /// Adapter for NLog logging framework.
    /// </summary>
    public class NLogAdapter : ILogger
    {
        #region Fields
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region ILogger methods
        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        public void Debug(string message) => logger.Debug(message);
        /// <summary>
        /// Writes exception at the Trace level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        public void Debug(Exception e) => logger.Debug(e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Debug level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        public void Debug(string message, Exception e) => logger.Debug(e, message);
        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        public void Error(string message) => logger.Error(message);
        /// <summary>
        /// Writes exception at the Error level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        public void Error(Exception e) => logger.Error(e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Error level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        public void Error(string message, Exception e) => logger.Error(e, message);
        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        public void Info(string message) => logger.Info(message);
        /// <summary>
        /// Writes exception at the Info level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        public void Info(Exception e) => logger.Info(e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Info level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        public void Info(string message, Exception e) => logger.Info(e, message);
        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        public void Trace(string message) => logger.Trace(message);
        /// <summary>
        /// Writes the exception at the Trace level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        public void Trace(Exception e) => logger.Trace(e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Trace level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        public void Trace(string message, Exception e) => logger.Trace(e, message);
        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        public void Warn(string message) => logger.Warn(message);
        /// <summary>
        /// Writes exception at the Warn level.
        /// </summary>
        /// <param name="e"> An exception to be logged.</param>
        public void Warn(Exception e) => logger.Warn(e);
        /// <summary>
        /// Writes the diagnostic message and exception at the Warn level.
        /// </summary>
        /// <param name="message"> A string to be written.</param>
        /// <param name="e"> An exception to be logged.</param>
        public void Warn(string message, Exception e) => logger.Warn(e, message);
        #endregion

    }
}
