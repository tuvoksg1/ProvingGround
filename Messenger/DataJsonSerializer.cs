using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Messenger
{
    public class DataJsonSerializer<T> where T : class
    {
        private readonly Encoding _encodeType;

        /// <summary>
        /// Initializes a new instance of the DataJsonSerializer class.
        /// </summary>
        protected DataJsonSerializer()
            : this(Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DataJsonSerializer class.
        /// </summary>
        /// <param name="encodeType">Type of the encoding to use</param>
        protected DataJsonSerializer(Encoding encodeType)
        {
            _encodeType = encodeType;
        }

        /// <summary>
        /// Serializes the object to a file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SerializeToFile(string filePath)
        {
            var jsonText = SerializeToJson();

            try
            {
                File.WriteAllText(filePath, jsonText, _encodeType);
            }
            catch (IOException exception)
            {
                string message = $"Path [{filePath}] contains one or more directories that do not exist";

                throw new SerializationException(message, exception);
            }
        }

        /// <summary>
        /// Serializes the object to a stream.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        public void SerializeToStream(Stream fileStream)
        {
            var jsonText = SerializeToJson();

            try
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(jsonText);
                }
            }
            catch (IOException exception)
            {
                const string message = "Unable to write object contents to stream";

                throw new SerializationException(message, exception);
            }
        }

        /// <summary>
        /// Serializes the object to a string of JSON.
        /// </summary>
        /// <returns>The JSON version of the object</returns>
        public string SerializeToJson()
        {
            return SerializeObject(this);
        }

        /// <summary>
        /// Deserializes from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The reconstructed object</returns>
        protected static T DeserializeFromFile(string filePath)
        {
            T result = null;

            if (!File.Exists(filePath)) return null;

            StreamReader reader = null;

            string jsonText;

            try
            {
                reader = new StreamReader(filePath);

                jsonText = reader.ReadToEnd();
            }
            finally
            {
                reader?.Close();
            }

            if (jsonText.Length > 0)
            {
                result = DeserializeFromJson(jsonText);
            }

            return result;
        }

        /// <summary>
        /// Deserializes from a JSON string.
        /// </summary>
        /// <param name="jsonText">The object JSON string.</param>
        /// <returns>The reconstructed object</returns>
        public static T DeserializeFromJson(string jsonText)
        {
            return DeserializeObject(jsonText, typeof(T)) as T;
        }

        private string SerializeObject(object instance)
        {
            var instanceData = string.Empty;

            if (instance != null)
            {
                try
                {
                    instanceData = JsonConvert.SerializeObject(instance, JsonSettings);
                }
                catch (Exception exception)
                {
                    string message = $"Unable to serialize {GetType().FullName}";

                    throw new SerializationException(message, exception);
                }
            }

            return instanceData;
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <param name="jsonText">The JSON string to deserialize from</param>
        /// <param name="deserializeType">The type of the object to deserialize.</param>
        /// <returns>The reconstructed object</returns>
        private static object DeserializeObject(string jsonText, Type deserializeType)
        {
            T result = null;

            if (!string.IsNullOrEmpty(jsonText) && !string.IsNullOrEmpty(jsonText.Trim()) && deserializeType != null)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<T>(jsonText, JsonSettings);
                }
                catch (Exception exception)
                {
                    string message = $"Unable to deserialize {deserializeType.FullName}.";

                    throw new SerializationException(message, exception);
                }
            }

            return result;
        }

        private static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Include
        };
    }
}
