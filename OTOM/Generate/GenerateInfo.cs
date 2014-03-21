using System.Collections.Generic;

namespace Otom.Core.Generate
{
    public class GenerateInfo
    {
        public ClassInfo SourceClass { get; set; }
        public ClassInfo DestinationClass { get; set; }
        public List<PropertyPair> Pairs { get; set; }
        public bool Reverse { get; set; }
    }
}
