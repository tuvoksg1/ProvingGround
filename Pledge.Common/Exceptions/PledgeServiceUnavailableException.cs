using System;

namespace Pledge.Common.Exceptions
{
    /// <summary>
    /// Thrown when an invalid configuration is detected
    /// </summary>
    public class PledgeServiceUnavailableException : Exception
    {
        /// <summary>
        /// Creates an exception with a user friendly message
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="message">The message.</param>
        public PledgeServiceUnavailableException(PledgeServiceType serviceType, string message) : base(message)
        {
            ServiceType = serviceType;
        }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        public PledgeServiceType ServiceType { get; }
    }

    /// <summary>
    /// The types of services on which Pledge relies
    /// </summary>
    public enum PledgeServiceType
    {
        /// <summary>
        /// The list service
        /// </summary>
        ListService,
        /// <summary>
        /// The audit service
        /// </summary>
        AuditService,
        /// <summary>
        /// The passport service
        /// </summary>
        PassportService
    }
}