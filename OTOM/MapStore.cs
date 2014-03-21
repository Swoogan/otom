using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Otom.Core
{
    public static class MapStore
    {
        public static void SaveToDisk(string path, MapFile mapping)
        {
            using (var fs = new FileStream(path, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, mapping);
                fs.Flush();
            }
        }

        public static MapFile LoadFromDisk(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var bf = new BinaryFormatter();
                var o = bf.Deserialize(fs);

                if (!(o is MapFile))
                    throw new ArgumentException("The file specified is not a OTOM mapping file.");

                return (MapFile)o;
            }
        }
    }
}
