using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Otom.Core
{
    [Serializable]
    public class Mapping
    {
        private readonly AssemblyInfo _destInfo;
        private readonly AssemblyInfo _sourceInfo;
        public List<PropertyMapping> PropertyMappings { get; private set; }

        public string SourceAssembly 
        {
            get { return _sourceInfo.Location; }
        }
        
        public string DestinationAssembly 
        {
            get { return _destInfo.Location; }
        }

        public Mapping(AssemblyInfo source, AssemblyInfo destination)
        {
            _sourceInfo = source;
            _destInfo = destination;

            PropertyMappings = new List<PropertyMapping>();
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
            return _sourceInfo.GetType(PropertyMappings[0].Source.Type);
        }

        public Type GetFirstDest()
        {
            return _destInfo.GetType(PropertyMappings[0].Destination.Type);
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
            PropertyMappings = new List<PropertyMapping>();
            foreach (PropertyMapping pair in pairs)
                PropertyMappings.Add(pair);
        }
    }
}