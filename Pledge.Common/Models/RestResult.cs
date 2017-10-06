using System.Collections.Generic;

namespace Pledge.Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestResult<T> where T : new()
    {

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long TotalHits { get; set; }
    }
}