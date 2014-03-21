using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Otom.Core
{
    [Serializable]
    public class Mapping
    {
        private readonly Assembly _destInfo;
        private readonly Assembly _sourceInfo;
        private List<PropertyMapping> _propertyMappings;

        public List<PropertyMapping> PropertyMappings
        {
            get { return _propertyMappings; }
        }

        public string SourceAssembly 
        {
            get { return _sourceInfo.Location; }
        }
        
        public string DestinationAssembly 
        {
            get { return _destInfo.Location; }
        }

        public Mapping(Assembly source, Assembly destination, IEnumerable pairs)
        {
            _sourceInfo = source;
            _destInfo = destination;

            _propertyMappings = new List<PropertyMapping>();
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
            return _sourceInfo.GetType(_propertyMappings[0].Source.Type);
        }

        public Type GetFirstDest()
        {
            return _destInfo.GetType(_propertyMappings[0].Destination.Type);
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

        public void SetPairs(IEnumerable pairs)
        {
            _propertyMappings = new List<PropertyMapping>();
            foreach (PropertyMapping pair in pairs)
                _propertyMappings.Add(pair);
        }
    }
}