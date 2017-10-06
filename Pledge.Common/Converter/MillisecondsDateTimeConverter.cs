using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pledge.Common.Converter
{
    /// <summary>
    /// 
    /// </summary>
    public class MillisecondsDateTimeConverter : DateTimeConverterBase
    {
        //private const string _error = "Unix epoc starts January 1st, 1970";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks;
            if (value is DateTime)
            {
                var epoc = new DateTime(1970, 1, 1);
                var delta = ((DateTime)value) - epoc;
                //if (delta.TotalSeconds < 0)
                //{
                //    throw new ArgumentOutOfRangeException(_error + $" date: {value}");
                //}
                ticks = (long)delta.TotalMilliseconds;
            }
            else
            {
                throw new Exception("Expected date object value.");
            }
            writer.WriteValue(ticks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            if (reader.TokenType != JsonToken.Integer)
            {
                throw new Exception(
                    $"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");
            }

            var ticks = (long)reader.Value;

            var date = new DateTime(1970, 1, 1);
            date = date.AddMilliseconds(ticks);

            return date;
        }
        
    }
}