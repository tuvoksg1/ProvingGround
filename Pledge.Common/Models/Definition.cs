namespace Pledge.Common.Models
{
    /// <summary>
    /// This class defines the information and properties of a particular column
    /// </summary>
    public class Definition
    {
        /// <summary>
        /// The column name
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// The column alias
        /// </summary>
        public string ColumnNameAlias { get; set; }
        /// <summary>
        /// Source column index - zero based ordinal position of the source column
        /// </summary>
        public int ColumnIndex { get; set; }
        /// <summary>
        /// Source column number - ordinal position of the source column
        /// </summary>
        public int? ColumnNumber { get; set; }
        /// <summary>
        /// The length of the source column (for fixed width formats)
        /// </summary>
        public int? ColumnLength { get; set; }
        /// <summary>
        /// The start position of the source column (for fixed width formats)
        /// </summary>
        public int? ColumnStart { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is virtual.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is virtual; otherwise, <c>false</c>.
        /// </value>
        public bool IsVirtual { get; set; }
    }

    /// <summary>
    /// This class add extra properties that apply to only output documents
    /// </summary>
    public class OutputDefinition : Definition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputDefinition"/> class.
        /// </summary>
        public OutputDefinition()
        {
            IsSelected = true;
        }

        /// <summary>
        /// The index of the corresponding input column
        /// </summary>
        public int InputColumnIndex { get; set; }

        /// <summary>
        /// The name of the corresponmding input column
        /// </summary>
        public string InputColumnName { get; set; }

        /// <summary>
        /// The output column is selected. Defaults to true
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
