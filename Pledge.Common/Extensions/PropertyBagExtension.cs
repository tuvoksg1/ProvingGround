using System.Collections.Generic;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// An extension class on the serializable dictionary class
    /// </summary>
    public static class PropertyBagExtension
    {
        /// <summary>
        /// Gets the property from the property bag if it exists and returns null if it doesn't.
        /// </summary>
        /// <param name="propertyBag">The property bag.</param>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static TK GetProperty<T, TK>(this IReadOnlyDictionary<T, TK> propertyBag, T property)
        {
            return !propertyBag.ContainsKey(property) ? default(TK) : propertyBag[property];
        }

        /// <summary>
        /// Gets the property from the property bag if it exists and returns a specified value if it doesn't.
        /// </summary>
        /// <param name="propertyBag">The property bag.</param>
        /// <param name="property">The property.</param>
        /// <param name="defaultValue">The default value to use if property is not present.</param>
        /// <returns></returns>
        public static T GetProperty<TK, T>(this IReadOnlyDictionary<TK, T> propertyBag, TK property, T defaultValue)
        {
            if (propertyBag == null)
            {
                return defaultValue;
            }

            return (!propertyBag?.ContainsKey(property) ?? false) ? defaultValue : propertyBag[property];
        }

        /// <summary>
        /// Gets the property from the property bag if it exists and returns a specified value if it doesn't.
        /// Specialised for string values to allow blank values in the dictionary to be replaced by the default.
        /// </summary>
        /// <param name="propertyBag">The property bag.</param>
        /// <param name="property">The property.</param>
        /// <param name="defaultValue">The default value to use if property is not present.</param>
        /// <returns></returns>
        public static string GetProperty<TK>(this IReadOnlyDictionary<TK, string> propertyBag, TK property, string defaultValue)
        {
            if (propertyBag == null) return defaultValue;
            if (!propertyBag.ContainsKey(property)) return defaultValue;
            var value = propertyBag[property];
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        /// <summary>
        /// Creates a new writeable dictionary from the supplied one
        /// </summary>
        /// <param name="propertyBag">The locked property bag.</param>
        /// <returns>A writeable property bag</returns>
        public static SerializableDictionary<TKey, TValue> Unlock<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> propertyBag)
        {
            var writableDictionary = new SerializableDictionary<TKey, TValue>();

            foreach (var key in propertyBag.Keys)
            {
                writableDictionary.Add(key, propertyBag[key]);
            }

            return writableDictionary;
        }

        /// <summary>
        /// Creates a new writeable dictionary from the supplied one and injects the supplied property
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="propertyBag">The locked property bag.</param>
        /// <param name="key">The key to inject.</param>
        /// <param name="value">The value to be injected.</param>
        /// <returns>
        /// A writeable property bag
        /// </returns>
        public static SerializableDictionary<TKey, TValue> Inject<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> propertyBag, TKey key, TValue value)
        {
            var writableDictionary = new SerializableDictionary<TKey, TValue>();

            foreach (var oldKey in propertyBag.Keys)
            {
                writableDictionary.Add(oldKey, propertyBag[oldKey]);
            }

            if (!writableDictionary.ContainsKey(key))
            {
                writableDictionary.Add(key, value);
            }

            return writableDictionary;
        }
    }
}
