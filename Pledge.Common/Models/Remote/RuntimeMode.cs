namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// The runtime mode for the current installation of Pledge
    /// </summary>
    public enum RuntimeMode
    {
        /// <summary>
        /// The installation depends on remote resources
        /// </summary>
        Remote,
        /// <summary>
        /// The installation has all resources provided locally
        /// </summary>
        Local
    }
}