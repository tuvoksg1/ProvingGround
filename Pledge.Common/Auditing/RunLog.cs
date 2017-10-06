using System;
using System.Collections.Generic;

namespace Pledge.Common.Auditing
{
    /// <summary>
    /// Contains all details about a running of a import process
    /// </summary>
    public class RunLog
    {
        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Gets or sets the tenant Id.
        /// </summary>
        public string TenantIdKey { get; set; }

        /// <summary>
        /// Gets or sets the tenant code.
        /// </summary>
        public string TenantCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the run identifier.
        /// </summary>
        public string RunIdKey { get; set; }

        /// <summary>
        /// Gets or sets the scheduled job identifier.
        /// </summary>
        public string ScheduledJobIdKey { get; set; }

        /// <summary>
        /// Gets or sets the configuration identifier.
        /// </summary>
        public string ConfigurationIdKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the configuration.
        /// </summary>
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the input file.
        /// </summary>
        public string InputName { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserIdKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserNameKey { get; set; }

        /// <summary>
        /// Gets or sets the total number of rows.
        /// </summary>
        public int NumberOfRows { get; set; }

        /// <summary>
        /// Gets or sets the number of failures.
        /// </summary>
        public int NumberOfFailures { get; set; }

        /// <summary>
        /// Gets or sets the number of passes.
        /// </summary>
        public int NumberOfPasses { get; set; }

        /// <summary>
        /// Identifier of the event
        /// </summary>
        public string RecordId { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }


        /// <summary>
        /// Creates the file process run log.
        /// </summary>
        /// <param name="loggingOptions">The logging options.</param>
        /// <returns></returns>
        public static RunLog CreateFileProcessRunLog(Dictionary<string, string> loggingOptions)
        {
            var logEntry = new RunLog()
            {
                Application = "Pledge",
                RecordId = new Guid().ToString()
            };
            
            return logEntry;
        }
    }
}
