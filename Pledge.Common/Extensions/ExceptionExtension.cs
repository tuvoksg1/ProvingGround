using System;
using System.Text;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// Extension class for all exceptions
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Extracts the messages.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="includeStackTrace">if set to <c>true</c> includes stack trace.</param>
        /// <returns></returns>
        public static string ExtractMessages(this Exception error, bool includeStackTrace = false)
        {
            var builder = new StringBuilder($"{error.Message}{Environment.NewLine}");

            var innerException = error.InnerException;

            while (innerException != null)
            {
                builder.AppendLine(innerException.Message);
                innerException = innerException.InnerException;
            }

            if (includeStackTrace)
            {
                builder.AppendLine(error.StackTrace);
            }

            return builder.ToString();
        }
    }
}
