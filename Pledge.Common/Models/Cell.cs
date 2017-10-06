namespace Pledge.Common.Models
{
    /// <summary>
    /// A cell in a document
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Gets or sets the column Index.
        /// </summary>
        /// <value>
        /// The column index.
        /// </value>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the value of the cell.
        /// </summary>
        /// <value>
        /// The cell value.
        /// </value>
        public string Value { get; set; }
    }
}