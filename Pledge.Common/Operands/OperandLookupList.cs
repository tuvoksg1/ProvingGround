using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pledge.Common.Extensions;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Operands
{
    /// <summary>
    /// Represents a wrapper around a list of IOprand objects
    /// </summary>
    public class OperandLookup : List<IOperand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperandLookup"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public OperandLookup(IReadOnlyList<IOperand> list)
        {
            SearchList = list.ToHashSet();
            AddRange(list);
        }

        /// <summary>
        /// Gets for the list for searching.
        /// </summary>
        public HashSet<string> SearchList { get; }
    }
}
