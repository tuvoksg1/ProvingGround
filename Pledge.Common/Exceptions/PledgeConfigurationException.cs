using System;

namespace Pledge.Common.Exceptions
{
    /// <summary>
    /// Thrown when an invalid configuration is detected
    /// </summary>
    public class PledgeConfigurationRuleException : Exception
    {
        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="message"></param>
        private PledgeConfigurationRuleException(string message) : base(message)
        {
            
        }

        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public PledgeConfigurationRuleException(string paramName, string message) : this($"{paramName}: {message}")
        {
            
        }
    }
}
