using System;
using System.Collections.Generic;

namespace Otom.Core
{
    [Serializable]
    public class MapFile
    {
        public MapTarget Source { get; set; }
        public MapTarget Destination { get; set; }
        public List<PropertyPair> PropertyPairs { get; set; }
    }
}
