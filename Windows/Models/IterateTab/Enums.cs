using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.Models.IterateTab
{
    public enum LogicType
    {
        And,
        Or
    }

    public enum NodeType
    {
        DoNothing,
        DoSomething
    }

    public enum ResultType
    {
        Pass,
        Fail,
        NotRun,
        Exception
    }

    public enum EvaluationOrder
    {
        ParentFirst,
        ChildrenFirst
    }
}
