namespace Pledge.Common.Models
{
    /// <summary>
    /// The mode of evaluating a rule
    /// </summary>
    public enum EvaluationMode
    {
        /// <summary>
        /// Indicates a rule will fail a record if its conditions are not met
        /// </summary>
        Active,
        /// <summary>
        /// Indicates a rule only evaluate its child rules if its conditions are met
        /// </summary>
        Passive
    }
}
