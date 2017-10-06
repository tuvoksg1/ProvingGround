using System.Threading;
using Pledge.Common.Models.Remote;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// The starting point for a process pipeline
    /// </summary>
    public interface IPipelineHead
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <param name="token">The token.</param>
        PipelinePayload Run(CancellationToken token);
    }
}
