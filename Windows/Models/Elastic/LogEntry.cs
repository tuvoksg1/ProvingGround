using System;

namespace Windows.Models.Elastic
{
    /// <summary>
    /// A log Entry
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        public LogEntry()
        {
            Timestamp = DateTime.UtcNow;
            MessageType = MessageType.Regular;
        }

        public int AuditId { get; set; }

        public string SessionId { get; set; }

        public string RunId { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public MessageType MessageType { get; set; }
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public string UpdatedBy { get; set; }
    }

    /// <summary>
    /// A type of audit message
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// An ad-hoc log entry
        /// </summary>
        Regular = 0,
        /// <summary>
        /// Indicates the start of a pledge run
        /// </summary>
        PledgeRun = 1,
        /// <summary>
        /// Indicates a configuration change
        /// </summary>
        Configuration = 2
    }
}
