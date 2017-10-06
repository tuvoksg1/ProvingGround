using System.Collections.Generic;
using System;
using System.Text;
using Pledge.Common.Exceptions;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// Extension methods for the String class
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert the operand's raw text value to a Decimal
        /// </summary>
        /// <param name="str">Input string that needs to transformed</param>
        /// <returns>The transformed string</returns>
        public static string DecodeDelimiter(this string str)
        {
            switch (str.ToLower())
            {
                case "tab":
                    return "\t";
                default:
                    return str;
            }
        }

        /// <summary>
        /// Converts the word TAB  to tab character
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeQualifier(this string str)
        {
            switch (str.ToLower())
            {
                case "tab":
                    return "\t";
                default:
                    return str;
            }
        }

        /// <summary>
        /// Parse a delimitered line when it could be either delimitered separated strings, delimitered separated text qualified strings, or a chaotic combination of the two.
        /// We first deal with qualifiers in the string (represented by double qualifier xters) by replacing with an obscure xter (which will be put back into the array. 
        /// Qualified string - delimitered string combos are only valid if there is an even number of qualifiers. 
        /// Qualifiers in a column value should be replaced with a pair of qualifiers (This is Excel's approach as discussed with DM and PO). 
        /// As long as the string line meets these requirements, you can expect the delimiter to appear only outside of pairs of qualifiers. 
        /// Delims inside of pairs of qualifiers are part of the column value and should be ignored when splitting the string into an array.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="delimiter"></param>
        /// <param name="qualifier"></param>   
        /// <param name="stopInvalidQualifier"></param>     
        /// <returns></returns>
        public static string[] SplitCustomExt(this string expression, string delimiter, string qualifier, bool stopInvalidQualifier = false)
        {
            const string obscureCharacter = "ᖳ";
            //when importing a delimited file where tab (\t) was the delimiter and the final fields of the record contained no
            //data, this process would return the wrong number of fields, only working up to the last populated field.
            //the problem is that .Trim() removes all white space characters and not just spaces, so the tab characters were being
            //removed after the last non-tab character
            char[] spaces = { ' ' };
            expression = expression.Trim(spaces);
 
            int len = expression.Length;
            List<string> list = new List<string>();
            int startField, endField; // text cursors

            if (delimiter.Equals(qualifier))
            {
                throw new PledgeColumnMismatchException("Delimiter and Qualifier cannot be the same");
            }
           
            if (expression.Contains(obscureCharacter)) throw new PledgeColumnMismatchException("Error: text data row may not contain the " + obscureCharacter + " character");

            //If expression has our double qualifier escape then lets replace it with our obscure character for now. We'll put it back once the array elements are built
            expression = expression.Replace(delimiter+qualifier + qualifier + qualifier, delimiter + qualifier + obscureCharacter + obscureCharacter);  // replace ,""" with ,"ᖳᖳ
            expression = expression.Replace(qualifier + qualifier + qualifier+ delimiter ,  obscureCharacter + obscureCharacter + qualifier + delimiter);  // replace """, with ᖳᖳ",
            expression = expression.Replace(qualifier + qualifier, obscureCharacter+ obscureCharacter); // replace remaining "" with ᖳᖳ

            for (startField = endField = 0; endField < len; startField = endField)
            {
                string s = expression[endField].ToString();
                bool entityContainsQualifiers = false;

                // move to the delimiter
                while (s != delimiter)
                {
                    if (s != qualifier)
                    {
                        // consume and continue if possible
                        ++endField;

                        if (len <= endField) { break; }
                        else { s = expression[endField].ToString(); continue; }
                    }

                    #region Consume Text Within Two Qualifiers

                    // we have the qualifier symbol
                    // then move to the closing one

                    entityContainsQualifiers = true;
                    bool foundClosingQualifier = false;

                    for (endField = endField + 1; endField < len; ++endField)
                    {
                        s = expression[endField].ToString();

                        if (endField + 1 < len)
                        {
                            if (s == qualifier && expression[endField + 1].ToString() == delimiter)
                            {
                                foundClosingQualifier = true;
                                break;
                            }
                        }
                        else
                        {
                            if (s == qualifier)
                            {
                                foundClosingQualifier = true;
                                break;
                            }
                        }
                    }

                    if (false == foundClosingQualifier)
                    {
                        throw new PledgeColumnMismatchException("Input data contains unmatched text qualifier");
                    }

                    // consume the closing quantifier and continue if possible
                    ++endField;

                    if (len <= endField) { break; }
                    else
                    {
                        s = expression[endField].ToString();
                    }

                    #endregion

                }

                // all what is in between begining Field and end Field cursors is the entity...
                var entity = expression.Substring(startField, endField - startField);

                if (stopInvalidQualifier)
                {
                    var inst = new List<int>();
                    var searchInt = new List<int> {0, -1, entity.Length - 1};
                    var index = 0;
                    while (index >= 0)
                    {
                        index = entity.IndexOf(qualifier, index, StringComparison.Ordinal);
                        if(!searchInt.Contains(index)) inst.Add(index);
                        if (index >= 0) index++;
                    }
                    if (inst.Count>0) throw new PledgeColumnMismatchException("Input data contains illegal text qualifier");
                }

                //If we are not stopping invalid qualifiers in the cell then remove them
                if (entityContainsQualifiers) entity = entity.Replace(qualifier, "");

                //Just an empty cell and not escape
                if (entity.Equals(obscureCharacter + obscureCharacter))
                {
                    entity = entity.Replace(obscureCharacter + obscureCharacter, "");
                }
                list.Add(entity);

                // two possibilities:
                // 1) we have found the delimiter
                // 2) we have came to the end of the expression
                // possibility (1)

                if (s == delimiter)
                {
                    // consume and continue if possible
                    ++endField;

                    if (len <= endField)
                    {
                        // this delimiter is the last symbol of the expression
                        // we should add the empty string as the last entity
                        // and leave
                        list.Add(string.Empty);
                        break;
                    }
                    else
                    {
                        // there are more entities in the expression
                        // proceed with collecting the entities
                        // note: s - initialization is done at the begining of the main cycle
                    }
                }
                else // possibility (2)
                {
                    // leave the cycle
                    break;
                }
            }

            //finally replace the double obscure xter with a single qualifier
            for (int i = 0; i < list.Count; i++)
            {
                list[i]= list[i].Replace(obscureCharacter+ obscureCharacter, qualifier);
            }
           
            return list.ToArray();
        }

        /// <summary>
        /// Case insensitive version of String.Replace().
        /// </summary>
        /// <param name="expression">String that contains patterns to replace</param>
        /// <param name="oldValue">Pattern to find</param>
        /// <param name="newValue">New pattern to replaces old</param>
        /// <param name="comparisonType">String comparison type</param>
        /// <returns></returns>
        public static string Replace(this string expression, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (expression == null)
                return null;

            if (string.IsNullOrEmpty(oldValue))
                return expression;

            var result = new StringBuilder(Math.Min(4096, expression.Length));
            var indexPosition = 0;

            while (true)
            {
                var foundIndex = expression.IndexOf(oldValue, indexPosition, comparisonType);
                if (foundIndex < 0)
                    break;

                result.Append(expression, indexPosition, foundIndex - indexPosition);
                result.Append(newValue);

                indexPosition = foundIndex + oldValue.Length;
            }

            result.Append(expression, indexPosition, expression.Length - indexPosition);

            return result.ToString();
        }
    }
}
