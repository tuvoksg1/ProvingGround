using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Utils
{
    public static class JsonHelper
    {
        public static void ToFile(object instance, string filePath)
        {
            var jsonText = ToText(instance);

            File.WriteAllText(filePath, jsonText, Encoding.UTF8);
        }

        public static string ToText(object instance)
        {
            return JsonConvert.SerializeObject(instance, JsonSettings);
        }

        public static T FromFile<T>(string file) where T : new()
        {
            if (string.IsNullOrEmpty(file))
            {
                return default(T);
            }

            if (File.Exists(file))
            {
                var jsonText = File.ReadAllText(file);

                if (!string.IsNullOrWhiteSpace(jsonText))
                {
                    return JsonConvert.DeserializeObject<T>(jsonText, JsonSettings);
                }
            }

            return new T();
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
