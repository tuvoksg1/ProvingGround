using System.Collections.Generic;
using Pledge.Common.Models.Automation;

namespace Pledge.Common.Interfaces.Automation
{
    /// <summary>
    /// Manages functions related to automation workflows
    /// </summary>
    public interface IWorkflowManager
    {
        /// <summary>
        /// Gets the server workflows.
        /// </summary>
        List<Workflow> GetServerWorkflows(PledgeData data);
        /// <summary>
        /// Gets the server workflow.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="data">The data.</param>
        Workflow GetServerWorkflow(string id, PledgeData data);    
        /// <summary>
        /// Adds the server workflow.
        /// </summary>
        Workflow AddServerWorkflow(Workflow workflow, PledgeData data);
        /// <summary>
        /// Updates the server workflow.
        /// </summary>
        void UpdateServerWorkflow(Workflow workflow, PledgeData data);
        /// <summary>
        /// Deletes the server workflow.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="data">The data.</param>
        void DeleteServerWorkflow(string id, PledgeData data);
        /// <summary>
        /// Executes the server workflow.
        /// </summary>
        /// <param name="workflowId">The workflow identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        void ExecuteServerWorkflow(string workflowId, string clientId);
    }
}