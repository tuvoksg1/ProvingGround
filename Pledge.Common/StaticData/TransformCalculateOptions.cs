using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The operators for Calculate option rules 
    /// </summary>
    public enum TransformCalculateOptions
    {
        /// <summary>
        /// Addition (Default) operator
        /// </summary>
        [Description("+")]
        Add,
        /// <summary>
        /// Subtract operator
        /// </summary>
       [Description("-")]
       Subtract,
       /// <summary>
       /// Multiply opertor
       /// </summary>
       [Description("*")]
       Multiply,
       /// <summary>
       /// Divide operator
       /// </summary>
       [Description("/")]
       Divide
    }
}
