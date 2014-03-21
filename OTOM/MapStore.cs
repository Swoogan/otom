using System;
using System.IO;
using System.Xml.Serialization;

namespace Otom.Core
{
    public static class MapStore
    {
        public static void SaveToDisk(string path, MapFile mapping)
        {
            var serialzier = new XmlSerializer(typeof (MapFile));
            using (var writer = new FileStream(path, FileMode.Create))
            {
                serialzier.Serialize(writer, mapping);
            }
        }

        public static MapFile LoadFromDisk(string path)
        {
            var serialzier = new XmlSerializer(typeof(MapFile));
            using (var reader = new FileStream(path, FileMode.Open))
            {
                var o = serialzier.Deserialize(reader);

                if (!(o is MapFile))
                    throw new ArgumentException("The file specified is not a OTOM mapping file.");

                return (MapFile)o;
            }
        }
    }
}
