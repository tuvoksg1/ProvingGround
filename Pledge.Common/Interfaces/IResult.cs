using System.Collections.Generic;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Result interface
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Result type property : READ ONLY
        /// </summary>
        ResultType Type { get;}
        /// <summary>
        /// Dispositions property : READ ONLY
        /// </summary>
        IReadOnlyList<IDisposition> Dispositions { get;}
        /// <summary>
        /// Gets the error messages: READ ONLY.
        /// </summary>
        IReadOnlyList<string> ErrorMessages { get; }
    }
}
