namespace Pledge.Common.Models
{
    /// <summary>
    /// A static class for application-wide variables
    /// </summary>
    public static class PledgeGlobal
    {
        /// <summary>
        /// The active connection
        /// </summary>
        public const string ActiveConnection = "ActiveConnection";
        /// <summary>
        /// The current version
        /// </summary>
        public const string CurrentVersion = "CurrentVersion";
        /// <summary>
        /// The rule matrix section
        /// </summary>
        public const string RuleMatrixSection = "RuleMatrix";
        /// <summary>
        /// The automation matrix section
        /// </summary>
        public const string AutomationMatrixSection = "AutomationMatrix";
        /// <summary>
        /// The rule matrix section
        /// </summary>
        public const string ExternalListProxy = "ExternalListProxy";
        /// <summary>
        /// The rule matrix section
        /// </summary>
        public const string ExternalListApiServer = "ExternalListApiServer";
        /// <summary>
        /// The property matrix section
        /// </summary>
        public const string PropertyMatrixSection = "PropertyMatrix";
        /// <summary>
        /// The disposition separator
        /// </summary>
        public const string DispositionSeparator = "^";
        /// <summary>
        /// The namespace property key for an ingest or egest medium
        /// </summary>
        public const string NamespaceKey = "MediumNamespace";
        /// <summary>
        /// The import folder property key
        /// </summary>
        public const string ImportFolderKey = "ImportFolder";
        /// <summary>
        /// The file pattern property key
        /// </summary>
        public const string FilePatternKey = "FilePattern";
        /// <summary>
        /// The export folder property key
        /// </summary>
        public const string ExportFolderKey = "ExportFolder";
        /// <summary>
        /// The pass file prefix property key
        /// </summary>
        public const string PassPrefixKey = "PassPrefix";
        /// <summary>
        /// The fail file prefix property key
        /// </summary>
        public const string FailPrefixKey = "FailPrefix";
        /// <summary>
        /// The maximum number of rows to output in each file
        /// </summary>
        public const string MaxRowsPerFileKey = "MaxRowsPerFile";
        /// <summary>
        /// The built in file system reader
        /// </summary>
        public const string BuiltInReader = "Pledge.Core.IO.FileSystemReader";
        /// <summary>
        /// The built in file system reader
        /// </summary>
        public const string BuiltInWriter = "Pledge.Core.IO.FileSystemWriter";
        /// <summary>
        /// The built in pledge implementation
        /// </summary>
        public const string BuiltInPledge = "Pledge.Core.Validator";
        /// <summary>
        /// The key for the archive location
        /// </summary>
        public const string ArchiveFolderKey = "ArchiveFolder";
        /// <summary>
        /// The housekeeping frequency for import folder
        /// </summary>
        public const string HousekeepingFrequencyImport = "HousekeepingFrequencyImport";
        /// <summary>
        /// The Session Id
        /// </summary>
        public const string SessionId = "SessionID";
        /// <summary>
        /// The CLient Id
        /// </summary>
        public const string ClientId = "ClientId";
        /// <summary>
        /// The Input file name
        /// </summary>
        public const string InputFileName = "InputFileName";
        /// <summary>
        /// The original batch name
        /// </summary>
        public const string OriginalBatchName = "OriginalBatchName";
        /// <summary>
        /// The Kafka message queue address
        /// </summary>
        public const string MessageQueueServer = "MessageQueueServer";
        /// <summary>
        /// The CX Dispatch server address
        /// </summary>
        public const string AuditReportServer = "AuditReportServer";
        /// <summary>
        /// The document index for pledge run events
        /// </summary>
        public const string PledgeIndexName = "PledgeIndexName";
        /// <summary>
        /// The document type for pledge run events
        /// </summary>
        public const string PledgeTypeName = "PledgeTypeName";
        /// <summary>
        /// The document index for pledge exceptions
        /// </summary>
        public const string ExceptionIndexName = "ExceptionIndexName";
        /// <summary>
        /// The Housekeeping Frequency Export
        /// </summary>
        public const string HousekeepingFrequencyExport = "HousekeepingFrequencyExport";
        /// <summary>
        /// Maximum file size for an uploaded file
        /// </summary>
        public const string MaxUploadFileSize = "MaxUploadFileSize";
        /// <summary>
        /// A flag to determine if system diagnostic tracing should be enabled
        /// </summary>
        public const string EnableTracing = "EnableTracing";
        /// <summary>
        /// String to store the octopus release version
        /// </summary>
        public const string ReleaseVersion = "ReleaseVersion";
        /// <summary>
        /// The Switch connection
        /// </summary>
        public const string SwitchDBConnection = "ActivatePostgresAndDisableMSSQL";
        /// <summary>
        /// The rule matrix section
        /// </summary>
        public const string PledgeRuntimeSection = "PledgeRuntime";
        /// <summary>
        /// The scheduled job identifier key
        /// </summary>
        public const string ScheduledJobIdKey = "JobId";
        /// <summary>
        /// The matching files key
        /// </summary>
        public const string MatchingFilesKey = "ProcessAllMatchingFiles";
        /// <summary>
        /// The scheduled job identifier key
        /// </summary>
        public const string PledgeWebApiAddress = "PledgeWebApiAddress";
        /// <summary>
        /// The matching files key
        /// </summary>
        public const string PledgeServiceAddress = "PledgeServiceAddress";
        /// <summary>
        /// Audit message type: Start of processing run
        /// </summary>
        public const string MessageTypeStartRun = "StartRun";
        /// <summary>
        /// Audit message type: End of processing run
        /// </summary>
        public const string MessageTypeEndRun = "EndRun";
        /// <summary>
        /// Audit message type: Exception occured
        /// </summary>
        public const string MessageTypeException = "Exception";
        /// <summary>
        /// Exception for config with Invalid or incomplete rule def
        /// </summary>
        public const string ExceptionConfigInvalidIncompleteRule = "The selected configuration has an invalid or incomplete rule definition.";
        /// <summary>
        /// Unexpected error in processing your request.
        /// </summary>
        public const string ExceptionUnexpectedProcessed = "There is an unexpected error in processing your request. Please try again.";
        /// <summary>
        /// Unexpected Exception
        /// </summary>
        public const string ExceptionUnexpected = "Pledge application had an unexpected error.";
        /// <summary>
        /// List folder invalid exception
        /// </summary>
        public const string ExceptionMissingListFolder = "Processing aborted - List container invalid";
        /// <summary>
        /// List Service unavailable exception
        /// </summary>
        public const string ExceptionServiceUnavailable = "Processing aborted - List service unavailable";
        /// <summary>
        /// List missing exception
        /// </summary>
        public const string ExceptionMissingList = "Processing aborted - List missing";
        /// <summary>
        /// List metadata missing Exception
        /// </summary>
        public const string ExceptionMissingListMetadata = "Processing aborted - List information missing";
        /// <summary>
        /// Memory Buffer Size
        /// </summary>
        public const string ReadMemoryBuffer = "ReadMemoryBuffer";
        /// <summary>
        /// Row Buffer Size
        /// </summary>
        public const string ReadRecordBuffer = "ReadRecordBuffer";
        /// <summary>
        /// Memory buffer for IO output component
        /// </summary>
        public const string WriteMemoryBuffer = "WriteMemoryBuffer";
        /// <summary>
        /// Record buffer for IO output component
        /// </summary>
        public const string WriteRowBuffer = "WriteRowBuffer";
        /// <summary>
        /// The default pledge pass prefix
        /// </summary>
        public const string PassPrefix = "PledgePass";
        /// <summary>
        /// The default pledge fail prefix
        /// </summary>
        public const string FailPrefix = "PledgeFail";
    }
}