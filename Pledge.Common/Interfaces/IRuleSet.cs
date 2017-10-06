using System.Collections.Generic;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Represents a single record to be verified/cleaned, such as a row from an input file.
    /// </summary>
    public interface IRuleSet : IReadOnlyList<IRule>
    {
        /// <summary>
        /// The current record against which the rules will be evaluated.
        /// </summary>
        IRecord CurrentRecord { set; }
    }
}