using System;
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

        public Mapping()
        {
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