namespace Pledge.Common.Models
{
    /// <summary>
    /// An enumerator of Rule LogType
    /// </summary>
    public enum RuleType
    {
        /// <summary>
        /// No rule
        /// </summary>
        None = 0,
        /// <summary>
        /// A rule that simply returns the value of the cell as the output
        /// </summary>
        Silent = 1,
        /// <summary>
        /// A rule that validates the equality between the value of the input and the supplied operand
        /// </summary>
        Equals,
        /// <summary>
        /// A rule that validates the difference between the value of the input and the supplied operand
        /// </summary>
        NotEqual,
        /// <summary>
        /// A rule that validates the size of the input against a smaller operand
        /// </summary>
        GreaterThan,
        /// <summary>
        /// A rule that validates the size of the input against a larger operand
        /// </summary>
        LessThan,
        /// <summary>
        /// A rule that validates the size of the input against a smaller or simliar sized operand
        /// </summary>
        GreaterThanOrEqualTo,
        /// <summary>
        /// A rule that validates the size of the input against a larger  or similar sized operand
        /// </summary>
        LessThanOrEqualTo,
        /// <summary>
        /// A rule that validates the input as a member of a sequence of operands
        /// </summary>
        Contains,
        /// <summary>
        /// A rule that validates the input is not a member of a sequence of operands
        /// </summary>
        DoesNotContain,
        /// <summary>
        /// A rule that validates the input is a date in the specified year
        /// </summary>
        Year,
        /// <summary>
        /// A rule that validates the input is of the specified length
        /// </summary>
        Length,
        /// <summary>
        /// A rule that specifies the input is within the specified range
        /// </summary>
        Between,
        /// <summary>
        /// Matches a regular expression
        /// </summary>
        Match,
        /// <summary>
        /// Does not match a regular expression.
        /// </summary>
        NotMatch,
        /// <summary>
        /// Matches whether the input can be found in a defined list
        /// </summary>
        InList,
        /// <summary>
        /// Matches whether the input can be found in an external list
        /// </summary>
        InExternalList,
        /// <summary>
        /// Matches whether the input cannot be found in an external list
        /// </summary>
        NotInExternalList,
        /// <summary>
        /// Matches whether the input cannot be found in a defined list
        /// </summary>
        NotInList,
        /// <summary>
        /// Matches whether the input is in a specified window
        /// </summary>
        Window,
        /// <summary>
        /// Sets a text value
        /// </summary>
        SetText,
        /// <summary>
        /// Sets a numeric value
        /// </summary>
        SetNumber,
        /// <summary>
        /// Sets a Date value
        /// </summary>
        SetDate,
        /// <summary>
        /// Matches whether the input is of a type date or number
        /// </summary>
        IsOfType,
        /// <summary>
        /// Appends or prepends value
        /// </summary>
        AppendValue,
        /// <summary>
        /// Changes the format of the date in the input
        /// </summary>
        SetDateFormat,
        /// <summary>
        /// Sets a Date value within the specified window
        /// </summary>
        SetDateWindow,
        /// <summary>
        /// Copies the value of one cell to another
        /// </summary>
        CopyFromCellToCell,
        /// <summary>
        /// Updates the date value of a cell
        /// </summary>
        UpdateDate,
        /// <summary>
        /// Set password based on window values (min max length) and options
        /// </summary>
        SetRandomCharacters,
        /// <summary>
        /// The lookup and replace rule
        /// </summary>
        LookupList,
        /// <summary>
        /// The copies a substring of a given text to a specified target
        /// </summary>
        Substring,
        /// <summary>
        /// Calculates source value based on the operators in the options
        /// </summary>
        CalCulateValue,
        /// <summary>
        /// Splits source string value by element and character and copies it to destination.
        /// </summary>
        SplitString,
        /// <summary>
        /// Replaces the regex character by a specified character. 
        /// </summary>
        PatternMatch
    }
}
