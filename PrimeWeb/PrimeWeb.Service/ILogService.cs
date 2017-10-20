using System;

namespace PrimeWeb.Service
{
    /// <summary>
    /// Logging service
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Post debug message
        /// </summary>
        /// <param name="message">string message for logging</param>
        void Debug(object message);

        /// <summary>
        /// Post debug message with exception
        /// </summary>
        /// <param name="message">string message for logging</param>
        /// <param name="exception">instance of deriveable from System.Exception</param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// Post error message
        /// </summary>
        /// <param name="message">string message for logging</param>
        void Error(object message);

        /// <summary>
        /// Post error message with exception
        /// </summary>
        /// <param name="message">string message for logging</param>
        /// <param name="exception">instance of deriveable from System.Exception</param>
        void Error(object message, Exception exception);

        /// <summary>
        /// Post fatal message
        /// </summary>
        /// <param name="message">string message for logging</param>
        void Fatal(object message);

        /// <summary>
        /// Post fatal message with exception
        /// </summary>
        /// <param name="message">string message for logging</param>
        /// <param name="exception">instance of deriveable from System.Exception</param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// Post information message
        /// </summary>
        /// <param name="message">string message for logging</param>
        void Info(object message);

        /// <summary>
        /// Post information message with exception
        /// </summary>
        /// <param name="message">string message for logging</param>
        /// <param name="exception">instance of deriveable from System.Exception</param>
        void Info(object message, Exception exception);

        /// <summary>
        /// Post warning message
        /// </summary>
        /// <param name="message">string message for logging</param>
        void Warn(object message);

        /// <summary>
        /// Post warning message with exception
        /// </summary>
        /// <param name="message">string message for logging</param>
        /// <param name="exception">instance of deriveable from System.Exception</param>
        void Warn(object message, Exception exception);
    }
}
