namespace Pledge.Common.Models
{
    /// <summary>
    /// Result type enumerator which could have value like Not Executed, Passed or Failed
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// Exception
        /// </summary>
        Exception,
        /// <summary>
        /// Result passed
        /// </summary>
        Passed,
        /// <summary>
        /// Result failed
        /// </summary>
        Failed
    }
}
