using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.Models.IterateTab
{
    public interface ITreeNode
    {
        string Name { get; }
        int Level { get; }
        NodeType Type { get; }
        LogicType LogicType { get; }
        IResult Outcome { get; }
        IEnumerable<ITreeNode> Children { get; }
        IResult Execute();
    }
}
