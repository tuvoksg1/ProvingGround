namespace Pledge.Common.Events
{
    /// <summary>
    /// Rule Failed Delegate
    /// </summary>
    /// <param name="disposition"></param>
    /// <param name="clientId">SignalR clientId</param>
    public delegate void RuleFailed(string disposition, string clientId);
    /// <summary>
    /// Validation complete delegate
    /// </summary>
    /// <param name="hasErrors"></param>
    /// /// <param name="clientId">SignalR clientId</param>
    public delegate void ValidationComplete(bool hasErrors, string clientId);
    /// <summary>
    /// Validation Progress delegate
    /// </summary>
    /// <param name="progress"></param>
    /// /// <param name="clientId">SignalR clientId</param>
    public delegate void ValidationProgress(int progress, string clientId);

    /// <summary>
    /// Workflow task progress delegate
    /// </summary>
    /// <param name="taskId">The task identifier.</param>
    /// <param name="progress">The progress.</param>
    /// <param name="clientId">The client identifier.</param>
    public delegate void WorkflowTaskProgress(string taskId, string progress, string clientId);

    /// <summary>
    /// Workflow failure delegate
    /// </summary>
    /// <param name="taskId">The task identifier.</param>
    /// <param name="clientId">The client identifier.</param>
    public delegate void WorkflowTaskUpdate(string taskId, string clientId);

    /// <summary>
    /// Workflow completion delegate
    /// </summary>
    /// <param name="succeeded">if set to <c>true</c> [succeeded].</param>
    /// <param name="clientId">The client identifier.</param>
    public delegate void WorkflowComplete(bool succeeded, string clientId);

    /// <summary>
    /// Class that manages all the events
    /// </summary>
    public static class EventsManager
    {
        /// <summary>
        /// This event is fired off when a rule fails
        /// </summary>
        public static event RuleFailed OnRuleFailed;
        /// <summary>
        /// This event is fired off when validation completed
        /// </summary>
        public static event ValidationComplete OnvalidationComplete;
        /// <summary>
        /// Event fired off when validation is in progress
        /// </summary>
        public static event ValidationProgress OnValidationProgress;
        /// <summary>
        /// Event fired when workflow task has started
        /// </summary>
        public static event WorkflowTaskUpdate OnTaskStarted;
        /// <summary>
        /// Event fired when workflow task is in progress
        /// </summary>
        public static event WorkflowTaskProgress OnTaskProgress;
        /// <summary>
        /// Event fired when workflow task has failed
        /// </summary>
        public static event WorkflowTaskUpdate OnTaskFailed;
        /// <summary>
        /// Event fired when workflow task has succeeded
        /// </summary>
        public static event WorkflowTaskUpdate OnTaskSucceeded;
        /// <summary>
        /// Event fired when workflow has completed
        /// </summary>
        public static event WorkflowComplete OnWorkflowCompleted;

        /// <summary>
        /// Validation progress Method. Checks and calls OnRuleFailed event
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="disposition"></param>
        /// <param name="clientId">SignalR clientId</param>
        public static void ReportRuleFailure(int rowNumber, string disposition, string clientId)
        {
            ReportRuleFailure($"Row {rowNumber}: {disposition}", clientId);
        }

        /// <summary>
        /// Validation progress Method. Checks and calls OnRuleFailed event
        /// </summary>
        /// <param name="disposition"></param>
        /// <param name="clientId">SignalR clientId</param>
        public static void ReportRuleFailure(string disposition, string clientId)
        {
            OnRuleFailed?.Invoke(disposition, clientId);
        }

        /// <summary>
        /// Report validation Complete Method. Checks and calls OnvalidationComplete
        /// </summary>
        /// <param name="hasErrors"></param>
        /// <param name="clientId">SignalR clientId</param>
        public static void ReportValidationComplete(bool hasErrors, string clientId)
        {
            OnvalidationComplete?.Invoke(hasErrors, clientId);
        }
        /// <summary>
        /// Report validation progross method. Checks and calls OnValidationProgress
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="clientId">SignalR clientId</param>
        public static void ReportValidationProgress(int progress, string clientId)
        {
            OnValidationProgress?.Invoke(progress, clientId);
        }

        /// <summary>
        /// Reports the task started.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        public static void ReportTaskStarted(string taskId, string clientId)
        {
            OnTaskStarted?.Invoke(taskId, clientId);
        }

        /// <summary>
        /// Reports the task progress.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="progress">The progress.</param>
        /// <param name="clientId">The client identifier.</param>
        public static void ReportTaskProgress(string taskId, int progress, string clientId)
        {
            OnTaskProgress?.Invoke(taskId, $"{progress}%", clientId);
        }

        /// <summary>
        /// Reports the task failure.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        public static void ReportTaskFailure(string taskId, string clientId)
        {
            OnTaskFailed?.Invoke(taskId, clientId);
        }

        /// <summary>
        /// Reports the task success.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        public static void ReportTaskSucceeded(string taskId, string clientId)
        {
            OnTaskSucceeded?.Invoke(taskId, clientId);
        }

        /// <summary>
        /// Reports the workflow completion.
        /// </summary>
        /// <param name="succeeded">if set to <c>true</c> [succeeded].</param>
        /// <param name="clientId">The client identifier.</param>
        public static void ReportWorkflowComplete(bool succeeded, string clientId)
        {
            OnWorkflowCompleted?.Invoke(succeeded, clientId);
        }
    }
}
