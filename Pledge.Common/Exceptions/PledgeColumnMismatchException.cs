using System;

namespace Pledge.Common.Exceptions
{
    /// <summary>
    /// Thrown when an invalid configuration is detected
    /// </summary>
    public class PledgeColumnMismatchException : Exception
    {

        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="message"></param>
        public PledgeColumnMismatchException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public PledgeColumnMismatchException(string paramName, string message) : this($"{paramName}: {message}")
        {

        }
    }
}
