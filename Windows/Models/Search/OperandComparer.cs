using System;
using System.Collections.Generic;
using Pledge.Common.Interfaces;

namespace Windows.Models.Search
{
    public class OperandComparer : IEqualityComparer<IOperand>
    {
        public bool Equals(IOperand first, IOperand second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null | second == null)
            {
                return false;
            }

            return first.TextValue().Equals(second.TextValue(), StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(IOperand obj)
        {
            return obj.TextValue().GetHashCode();
        }
    }
}
