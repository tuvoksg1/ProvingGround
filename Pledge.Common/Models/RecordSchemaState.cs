namespace Pledge.Common.Models
{
    /// <summary>
    /// The state of the record in correlation with the active input schema
    /// </summary>
    public enum RecordSchemaState
    {
        /// <summary>
        /// The record matches schema
        /// </summary>
        MatchesSchema,
        /// <summary>
        /// The record has missing columns
        /// </summary>
        HasMissingColumns,
        /// <summary>
        /// The record has extra columns
        /// </summary>
        HasExtraColumns
    }
}
