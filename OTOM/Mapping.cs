using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OTOM
{
    [Serializable]
    public class Mapping
    {
        public string SourceAssembly { get; set; }
        public string DestinationAssembly { get; set; }
        public List<PropertyMapping> PropertyMappings { get; set; }

        public Mapping(IList pairs)
        {
            var propertyPair = (PropertyPair)pairs[0];

            if (propertyPair.Source.DeclaringType == null)
                throw new ArgumentException("Source declaring type must not be null");
            SourceAssembly = propertyPair.Source.DeclaringType.Assembly.Location;

            if (propertyPair.Destination.DeclaringType == null)
                throw new ArgumentException("Destination declaring type must not be null");
            DestinationAssembly = propertyPair.Destination.DeclaringType.Assembly.Location;

            PropertyMappings = new List<PropertyMapping>();
            foreach (PropertyPair pair in pairs)
            {
                PropertyMappings.Add(new PropertyMapping(pair));
            }
        }

        public void SaveToDisk(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, this);
                fs.Flush();
            }
        }

        public static Mapping LoadFromDisk(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var bf = new BinaryFormatter();
                var o = bf.Deserialize(fs);

                if (!(o is Mapping))
                    throw new ArgumentException("The file specified is not a OTOM mapping file.");

                return (Mapping) o;
            }
        }
    }
}