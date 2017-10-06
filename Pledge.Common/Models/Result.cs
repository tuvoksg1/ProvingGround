using System.Collections.Generic;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models
{
    /// <summary>
    /// Class object to contains the Results which include a result type (such as pass,fail or not executed),
    /// the disposition and the output
    /// </summary>
    public class Result : IResult
    {
        private readonly List<IDisposition> _dispositions;
        private readonly List<string> _errorMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result" /> class.
        /// </summary>
        /// <param name="type">The result type.</param>
        /// <param name="disposition">The disposition.</param>
        /// <param name="errorMessage">The error message.</param>
        public Result(ResultType type, Disposition disposition = null, string errorMessage = null)
        {
            _dispositions = new List<IDisposition>();
            _errorMessages = new List<string>();

            Type = type;

            if (disposition != null)
            {
                _dispositions.Add(disposition);
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                _errorMessages.Add(errorMessage);
            }
        }

        /// <summary>
        /// Result type enumerator which could have value like Not Executed, Passed or Failed
        /// </summary>
        public ResultType Type { get; set; }

        /// <summary>
        /// Disposition value or text
        /// </summary>
        public IReadOnlyList<IDisposition> Dispositions => _dispositions;

        /// <summary>
        /// Gets the error message when there is an exception.
        /// </summary>
        public IReadOnlyList<string> ErrorMessages => _errorMessages;

        /// <summary>
        /// Adds the disposition.
        /// </summary>
        /// <param name="dispositons">The dispositon.</param>
        public void AddDispositions(IEnumerable<IDisposition> dispositons)
        {
            if (dispositons == null)
            {
                return;
            }

            _dispositions.AddRange(dispositons);
        }

        /// <summary>
        /// Adds the error messages.
        /// </summary>
        /// <param name="errorMessages">The error messages.</param>
        public void AddErrorMessages(IEnumerable<string> errorMessages)
        {
            if (errorMessages == null)
            {
                return;
            }

            _errorMessages.AddRange(errorMessages);
        }

        /// <summary>
        /// Creates a cumulative result that contains all previous dispositions and error messages
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="otherResult">The result to aggregate into the result.</param>
        /// <param name="logicType">The logic type</param>
        public static IResult Aggregate(IResult result, IResult otherResult, LogicType logicType)
        {
            var aggregateResult = new Result(result.Type);
            aggregateResult.AddDispositions(otherResult.Dispositions);
            aggregateResult.AddErrorMessages(otherResult.ErrorMessages);
            aggregateResult.AddDispositions(result.Dispositions);
            aggregateResult.AddErrorMessages(result.ErrorMessages);

            //make sure any previous failures are reported UNLESS we are an Or rule
            if (logicType == LogicType.And && otherResult.Type != ResultType.Passed)
            {
                aggregateResult.Type = otherResult.Type;
            }

            return aggregateResult;
        }
    }
}