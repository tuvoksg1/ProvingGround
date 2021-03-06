﻿namespace Pledge.Common
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Base class for serializing and deserializing objects
    /// </summary>
    public class InfoSerializer<T> where T : class
    {
        private readonly Encoding _encodeType;
        private XmlWriterSettings _settings;

        /// <summary>
        /// Initializes a new instance of the InfoSerializer class.
        /// </summary>
        protected InfoSerializer()
            : this(Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InfoSerializer class.
        /// </summary>
        /// <param name="encodeType">LogType of the encoding to use</param>
        protected InfoSerializer(Encoding encodeType)
        {
            _encodeType = encodeType;
        }

        /// <summary>
        /// Serializes the object to a file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SerializeToFile(string filePath)
        {
            var xml = SerializeToXml();

            try
            {
                using (var memStream = new MemoryStream(_encodeType.GetBytes(xml)))
                {
                    //calling doc.LoadXml with the xml variable will not work
                    //as the string value is not valid xml
                    var doc = new XmlDocument();
                    doc.Load(memStream);

                    using (var writer = XmlWriter.Create(filePath, XmlWriterSettings))
                    {
                        doc.Save(writer);
                    }
                }
            }
            catch (DirectoryNotFoundException exception)
            {
                string message = $"Path [{filePath}] contains one or more directories that do not exist";

                throw new SerializationException(message, exception);
            }
        }

        /// <summary>
        /// Serializes the object to a file.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        public void SerializeToFile(Stream fileStream)
        {
            var xml = SerializeToXml();

            try
            {
                using (var memStream = new MemoryStream(_encodeType.GetBytes(xml)))
                {
                    //calling doc.LoadXml with the xml variable will not work
                    //as the string value is not valid xml
                    var doc = new XmlDocument();
                    doc.Load(memStream);

                    using (var writer = XmlWriter.Create(fileStream, XmlWriterSettings))
                    {
                        doc.Save(writer);
                    }
                }
            }
            catch (IOException exception)
            {
                const string message = "Unable to write object contents to stream";

                throw new SerializationException(message, exception);
            }
        }

        /// <summary>
        /// Serializes the object to a string of xml.
        /// </summary>
        /// <returns>The xml version of the object</returns>
        public string SerializeToXml()
        {
            return SerializeObject(this, GetType());
        }

        /// <summary>
        /// Deserializes from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>An instance of the object</returns>
        public static T DeserializeFromFile(string filePath)
        {
            return DeserializeFromFile(filePath, typeof(T)) as T;
        }

        /// <summary>
        /// Deserializes from XML.
        /// </summary>
        /// <param name="objectXml">The object XML.</param>
        /// <returns>An instance of the object</returns>
        public static T DeserializeFromXml(string objectXml)
        {
            return DeserializeFromXml(objectXml, typeof(T)) as T;
        }


        /// <summary>
        /// Deserializes from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="deserializeType">LogType to deserialize.</param>
        /// <returns>The reconstructed object</returns>
        protected static object DeserializeFromFile(string filePath, Type deserializeType)
        {
            object result = null;

            if (!File.Exists(filePath)) return null;

            StreamReader reader = null;

            string xml;

            try
            {
                reader = new StreamReader(filePath);

                xml = reader.ReadToEnd();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            if (xml.Length > 0)
            {
                result = DeserializeFromXml(xml, deserializeType);
            }

            return result;
        }

        /// <summary>
        /// Deserializes from an xml string.
        /// </summary>
        /// <param name="objectXml">The object XML.</param>
        /// <param name="deserializeType">LogType to deserialize.</param>
        /// <returns>The reconstructed object</returns>
        protected static object DeserializeFromXml(string objectXml, Type deserializeType)
        {
            return DeserializeObject(objectXml, deserializeType);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <param name="xml">The xml string to deserialize from</param>
        /// <param name="deserializeType">The type of the object to deserialize.</param>
        /// <returns>The reconstructed object</returns>
        protected static object DeserializeObject(string xml, Type deserializeType)
        {
            object result = null;

            if (!string.IsNullOrEmpty(xml) && !string.IsNullOrEmpty(xml.Trim()) && deserializeType != null)
                try
                {
                    using (var reader = new StringReader(xml))
                    {
                        //create a reader to read the attachments file in
                        using (var xmlReader = new XmlTextReader(reader))
                        {

                            //create the serialized
                            var xmlSerializer = new XmlSerializer(deserializeType);

                            //deserialize
                            result = xmlSerializer.Deserialize(xmlReader);
                        }
                    }
                }
                catch (Exception exception)
                {
                    string message = $"Unable to deserialize {deserializeType.FullName}.";

                    throw new SerializationException(message, exception);
                }

            return result;
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="serializeData">The object to serialize.</param>
        /// <param name="serializeType">The type of the object to serialize.</param>
        /// <returns>The xml serialized version of the object</returns>
        protected string SerializeObject(object serializeData, Type serializeType)
        {
            var xml = string.Empty;

            if (serializeData != null && serializeType != null)
            {
                try
                {
                    MemoryStream memoryStream;

                    using (memoryStream = new MemoryStream())
                    {
                        using (var xmlTextWriter = new XmlTextWriter(memoryStream, _encodeType))
                        {
                            var typedSerializer = new XmlSerializer(serializeType);

                            //dump the serialized content in the writer
                            typedSerializer.Serialize(xmlTextWriter, serializeData);

                            //get a copy of the data and convert to a string
                            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                            var data = memoryStream.ToArray();
                            xml = _encodeType.GetString(data);

                            if (!string.IsNullOrEmpty(xml) && xml.Length > 0)
                            {
                                var preamble = _encodeType.GetString(_encodeType.GetPreamble());
                                xml = xml.Remove(0, preamble.Length);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    string message = $"Unable to serialize {GetType().FullName} to file.";

                    throw new SerializationException(message, exception);
                }
            }

            return xml;
        }

        private XmlWriterSettings XmlWriterSettings
        {
            get
            {
                if (_settings != null)
                {
                    return _settings;
                }

                _settings = new XmlWriterSettings
                {
                    ConformanceLevel = ConformanceLevel.Document,
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = Environment.NewLine,
                    OmitXmlDeclaration = false,
                    Encoding = _encodeType
                };

                return _settings;
            }
        }
    }
}
