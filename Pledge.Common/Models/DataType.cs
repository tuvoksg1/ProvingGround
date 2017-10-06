using System.Runtime.Serialization;

namespace Pledge.Common.Models
{
    /// <summary>
    /// An enumeration of possible data types
    /// </summary>
    [DataContract]
    public enum DataType
    {
        /// <summary>
        /// Text data
        /// </summary>
        [EnumMember]
        Text = 0,
        /// <summary>
        /// Numerical data
        /// </summary>
        [EnumMember]
        Number = 1,
        /// <summary>
        /// Date or datetime data
        /// </summary>
        [EnumMember]
        Date = 3,
        /// <summary>
        /// A group type
        /// </summary>
        [EnumMember]
        Group = 4,
        /// <summary>
        /// Data Transformation
        /// </summary>
        [EnumMember]        
        Transform = 5
    }
}
