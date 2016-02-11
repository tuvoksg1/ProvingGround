using System;
using System.Collections.Generic;
using LoggingUtility;

namespace Windows.Models.Serialization
{
    public class ComplexObject : InfoSerializer<ComplexObject>
    {
        public string Name { get; set; }
        public Guid Identifier { get; set; }
        public SerializableDictionary<string, string> Settings { get; set; }
    }
}
