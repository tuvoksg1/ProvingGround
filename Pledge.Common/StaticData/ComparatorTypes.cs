using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The comparator options for static value and column picker
    /// </summary>
    public enum ValueColumnOptions
    {
        /// <summary>
        /// The targets comparator type is static data value
        /// </summary>
        [Description("Value")]
        Value,
        /// <summary>
        /// The targets comparator type is column
        /// </summary>
        [Description("Column")]
        Column
    }

    /// <summary>
    /// The comparator options for static list only
    /// </summary>
    public enum ListOptions
    {
        /// <summary>
        /// The targets comparator type is static list
        /// </summary>
        [Description("List")]
        List
    }

    /// <summary>
    /// The comparator options for static value, static list and column picker
    /// </summary>
    public enum ValueListColumnOptions
    {
        /// <summary>
        /// The targets comparator type is static data value
        /// </summary>
        [Description("Value")]
        Value,
        /// <summary>
        /// The targets comparator type is static list
        /// </summary>
        [Description("List")]
        List,
        /// <summary>
        /// The targets comparator type is static list
        /// </summary>
        [Description("Named List")]
        NamedList,
        /// <summary>
        /// The targets comparator type is column
        /// </summary>
        [Description("Column")]
        Column
    }

    /// <summary>
    /// The comparator options for static date and column picker
    /// </summary>
    public enum DateColumnOptions
    {
        /// <summary>
        /// The targets comparator type is static data value
        /// </summary>
        [Description("Date")]
        Date,
        /// <summary>
        /// The targets comparator type is column
        /// </summary>
        [Description("Column")]
        Column
    }

    /// <summary>
    /// The comparator options for both internal and external lists
    /// </summary>
    public enum MixedListOptions
    {
        /// <summary>
        /// The targets comparator type is static list
        /// </summary>
        [Description("List")]
        List,
        /// <summary>
        /// The targets comparator type is external named list
        /// </summary>
        [Description("Named List")]
        NamedList
    }

    /// <summary>
    /// The comparator options for both internal and external lists
    /// </summary>
    public enum ValueMetaOptions
    {
        /// <summary>
        /// The targets comparator type is static value
        /// </summary>
        [Description("Value")]
        Value,
        /// <summary>
        /// The targets comparator type is filename metadata
        /// </summary>
        [Description("[Name of file]")]
        Filename
    }
}
