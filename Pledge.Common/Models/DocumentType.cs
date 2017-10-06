namespace Pledge.Common.Models
{
    /// <summary>
    /// This is an enumuration of document types such as delimitered (e.g. CSVs or delimitered text files)
    /// or fixed width files with data colums represented by start and end positions 
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// The document type was unspecified
        /// </summary>
        Unspecified,
        /// <summary>
        /// Fixed width files
        /// </summary>
        FixedLength,
        /// <summary>
        /// Delimitered files
        /// </summary>
        Delimited
    }
}
