using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.Models.IterateTab
{
    public class BaseNode : ITreeNode
    {
        protected BaseNode()
        {
            Children = new List<ITreeNode>();
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public NodeType Type { get; protected set; }
        public LogicType LogicType { get; set; }
        public IResult Outcome { get; set; }
        public IEnumerable<ITreeNode> Children { get; set; }

        public IResult Execute()
        {
            return Outcome;
        }

        public override string ToString()
        {
            return $"Level {Level}:  {Name} - {Outcome.Type}";
        }
    }
}
