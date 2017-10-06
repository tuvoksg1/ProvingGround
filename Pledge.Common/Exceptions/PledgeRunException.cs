using System;

namespace Pledge.Common.Exceptions
{
    /// <summary>
    /// Thrown when a fatal error occurs during a pledge run
    /// </summary>
    public class PledgeRunException : Exception
    {
        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="message"></param>
        public PledgeRunException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public PledgeRunException(string paramName, string message) : this($"{paramName}: {message}")
        {

        }
    }
}
