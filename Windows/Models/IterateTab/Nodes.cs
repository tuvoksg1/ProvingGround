using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.Models.IterateTab
{
    public class DoNothingNode : BaseNode
    {
        public DoNothingNode()
        {
            Name = "Do Nothing";
            Level = 1;
            Type = NodeType.DoNothing;
            LogicType = LogicType.And;
            Outcome = new Result {Type = ResultType.Pass};
        }
    }

    public class DoSomethingNode : BaseNode
    {
        public DoSomethingNode()
        {
            Type = NodeType.DoSomething;
        }
    }
}
