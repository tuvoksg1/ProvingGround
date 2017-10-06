using System;

namespace Pledge.Common.Exceptions
{
    /// <summary>
    /// Thrown when an invalid configuration is detected
    /// </summary>
    public class PledgeMissingListMetadataException : Exception
    {

        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="message"></param>
        public PledgeMissingListMetadataException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public PledgeMissingListMetadataException(string paramName, string message) : this($"{paramName}: {message}")
        {

        }
    }
}