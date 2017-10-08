using System;
using System.Collections.Generic;
using System.Linq;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// Applies a hash lookup on an IOperand collection
    /// </summary>
    public static class LookupExtension
    {
        /// <summary>
        /// Creates a hashset from the IOperand collection
        /// </summary>
        /// <param name="list">The operand list from which a hash set will be created.</param>
        /// <returns>A search-optimised hash set</returns>
        public static HashSet<string> ToHashSet(this IReadOnlyList<IOperand> list)
        {
            var textList = list.Select(arg => arg.TextValue());
            return new HashSet<string>(textList, StringComparer.OrdinalIgnoreCase);
        }
    }
}
