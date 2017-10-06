namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Disposition interface
    /// </summary>
    public interface IDisposition
    {
        /// <summary>
        /// Annotation property.
        /// </summary>
        string Annotation { get; set; }
        /// <summary>
        /// Failure code property.
        /// </summary>
        string FailureCode { get; set; }
    }
}
