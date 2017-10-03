using Newtonsoft.Json.Linq;

namespace Messenger
{
    /// <summary>
    /// Extension class for various Newtonsoft.Json objects
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Add a new child object with the specified name and return it
        /// </summary>
        /// <param name="parent">Parent object</param>
        /// <param name="name">Name of child object</param>
        /// <returns></returns>
        public static JObject AddObject(this JObject parent, string name)
        {
            var obj = new JObject();
            parent.Add(name, obj);
            return obj;
        }

        /// <summary>
        /// Add a new child object to the arary and return it
        /// </summary>
        /// <param name="parent">Parent array</param>
        /// <returns></returns>
        public static JObject AddObject(this JArray parent)
        {
            var obj = new JObject();
            parent.Add(obj);
            return obj;
        }

        /// <summary>
        /// Add a new child array with the specified name and return it
        /// </summary>
        /// <param name="parent">Parent object</param>
        /// <param name="name">Name of the child array</param>
        /// <returns></returns>
        public static JArray AddArray(this JObject parent, string name)
        {
            var obj = new JArray();
            parent.Add(name, obj);
            return obj;
        }
    }
}
