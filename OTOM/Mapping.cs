using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Otom.Core
{
    [Serializable]
    public class Mapping
    {
        private readonly AssemblyInfo _destInfo;
        private readonly AssemblyInfo _sourceInfo;
        public string SourceAssembly { get; set; }
        public string DestinationAssembly { get; set; }
        public List<PropertyMapping> PropertyMappings { get; set; }

        public Mapping(IList pairs)
        {
            var propertyPair = (PropertyPair)pairs[0];

            if (propertyPair.Source.DeclaringType == null)
                throw new ArgumentException("Source declaring type must not be null");
            SourceAssembly = propertyPair.Source.DeclaringType.Assembly.Location;
            _sourceInfo = new AssemblyInfo(SourceAssembly);

            if (propertyPair.Destination.DeclaringType == null)
                throw new ArgumentException("Destination declaring type must not be null");
            DestinationAssembly = propertyPair.Destination.DeclaringType.Assembly.Location;
            _destInfo = new AssemblyInfo(DestinationAssembly);

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

        public Type GetFirstSource()
        {
            return _sourceInfo.GetTypeByName(PropertyMappings[0].SourceType);
        }

        public Type GetFirstDest()
        {
            return _destInfo.GetTypeByName(PropertyMappings[0].DestinationType);
        }

        public IEnumerable<Object> GetPairs()
        {
            return PropertyMappings.Select(propMapping => new PropertyPair
            {
                Source = _sourceInfo.GetPropertyByName(propMapping.SourceType, propMapping.SourceName),
                Destination = _destInfo.GetPropertyByName(propMapping.DestinationType, propMapping.DestinationName)
            });
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