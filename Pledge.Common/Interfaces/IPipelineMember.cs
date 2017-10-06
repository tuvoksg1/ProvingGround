using Pledge.Common.Models.Remote;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// A component part of a pipeline
    /// </summary>
    public interface IPipelineMember
    {
        /// <summary>
        /// Adds the record to the component's queue.
        /// </summary>
        /// <param name="record">The record.</param>
        void AddRecord(IRecord record);

        /// <summary>
        /// Ends the pipeline.
        /// </summary>
        PipelinePayload EndPipeline();
    }
}
