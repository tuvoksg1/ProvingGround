using System.Collections.Generic;
using System.Linq;

namespace Windows.Models.IterateTab
{
    public static class NodeData
    {
        public static IEnumerable<ITreeNode> GetNodes()
        {
            var nodes = new List<ITreeNode>
            {
                new DoSomethingNode
                {
                    Name = "R1",
                    Level = 1,
                    Outcome = new Result {Type = ResultType.Pass},
                    LogicType = LogicType.And
                },
                new DoNothingNode
                {
                    Children = new List<ITreeNode>
                    {
                        new DoSomethingNode
                        {
                            Name = "R2",
                            Level = 2,
                            Outcome = new Result {Type = ResultType.Pass},
                            LogicType = LogicType.And,
                            Children = new List<ITreeNode>
                            {
                                new DoSomethingNode
                                {
                                    Name = "R3",
                                    Level = 3,
                                    Outcome = new Result {Type = ResultType.Pass},
                                    LogicType = LogicType.And
                                },
                                new DoSomethingNode
                                {
                                    Name = "R4",
                                    Level = 3,
                                    Outcome = new Result {Type = ResultType.Pass},
                                    LogicType = LogicType.And
                                }
                            }
                        }
                    }
                },
                new DoSomethingNode
                {
                    Name = "R5",
                    Level = 1,
                    Outcome = new Result {Type = ResultType.Pass},
                    LogicType = LogicType.And,
                    Children = new List<ITreeNode>
                    {
                        new DoSomethingNode
                        {
                            Name = "R6",
                            Level = 2,
                            Outcome = new Result {Type = ResultType.Pass},
                            LogicType = LogicType.Or,
                            Children = new List<ITreeNode>
                            {
                                new DoSomethingNode
                                {
                                    Name = "R7",
                                    Level = 3,
                                    Outcome = new Result {Type = ResultType.Pass},
                                    LogicType = LogicType.And,
                                    Children = new List<ITreeNode>
                                    {
                                        new DoSomethingNode
                                        {
                                            Name = "R8",
                                            Level = 3,
                                            Outcome = new Result {Type = ResultType.Pass},
                                            LogicType = LogicType.Or
                                        },
                                        new DoSomethingNode
                                        {
                                            Name = "R9",
                                            Level = 3,
                                            Outcome = new Result {Type = ResultType.Pass},
                                            LogicType = LogicType.Or
                                        }
                                    }
                                }
                            }
                        },
                        new DoSomethingNode
                        {
                            Name = "R10",
                            Level = 2,
                            Outcome = new Result {Type = ResultType.Pass},
                            LogicType = LogicType.Or,
                            Children = new List<ITreeNode>
                            {
                                new DoSomethingNode
                                {
                                    Name = "R11",
                                    Level = 3,
                                    Outcome = new Result {Type = ResultType.Fail},
                                    LogicType = LogicType.And,
                                    Children = new List<ITreeNode>
                                    {
                                        new DoSomethingNode
                                        {
                                            Name = "R12",
                                            Level = 3,
                                            Outcome = new Result {Type = ResultType.Pass},
                                            LogicType = LogicType.And
                                        },
                                        new DoSomethingNode
                                        {
                                            Name = "R13",
                                            Level = 3,
                                            Outcome = new Result {Type = ResultType.Pass},
                                            LogicType = LogicType.And
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new DoNothingNode(),
            };

            return nodes;
        }

        public static IResult Evaluate(this ITreeNode node, IResult rollingResult)
        {
            var nodeResult = node.Execute();

            //if I failed and have children don't bother aggregating the results
            if (nodeResult.Type != ResultType.Pass && node.Children.Any())
            {
                return nodeResult;
            }

            switch (node.LogicType)
            {
                case LogicType.Or:
                    return rollingResult.Type == ResultType.Pass ? rollingResult : nodeResult;
                default:
                    return rollingResult.Type == ResultType.Pass ? nodeResult : rollingResult;
            }
        }

        public static IEnumerable<ITreeNode> GetEnumerable(this ITreeNode node, EvaluationOrder evaluationOrder)
        {
            if (evaluationOrder == EvaluationOrder.ParentFirst)
            {
                yield return node;
            }

            if (node.Outcome.Type == ResultType.Pass)
            {
                foreach (var child in node.Children)
                {
                    var childEnumerator = child.GetEnumerable(evaluationOrder).GetEnumerator();

                    while (childEnumerator.MoveNext())
                    {
                        yield return childEnumerator.Current;
                    }
                }
            }

            if (evaluationOrder == EvaluationOrder.ChildrenFirst)
            {
                yield return node;
            }
        }
    }
}
