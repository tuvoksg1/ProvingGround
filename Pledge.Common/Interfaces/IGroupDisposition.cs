namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Group disposition interface
    /// </summary>
    public interface IGroupDisposition
    {
        /// <summary>
        /// Highest group failure code property.
        /// </summary>
        string FailureCode { get; set; }
        /// <summary>
        /// Aggregated rule results property.
        /// </summary>
        IResult AggregateResult { get; set; }
    }
}