using System.Xml.Serialization;

namespace Pledge.Common.Models
{
    /// <summary>
    /// An operand which represents data against which a record cell will be evaluated by a rule
    /// </summary>
    public class Operand
    {
        /// <summary>
        /// Gets or sets a value indicating whether this operand is a column.
        /// </summary>
        [XmlAttribute("IsColumn")]
        public bool IsColumn { get; set; }

        /// <summary>
        /// Gets or sets the index of the column the operand refernces.
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// Gets or sets the value of the operand
        /// </summary>
        public object Value { get; set; }
    }
}
