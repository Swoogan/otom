using System;

namespace Otom.Core
{
    [Serializable]
    public class PropertyMapping
    {
        public string SourceName { get; set; }
        public string SourceType { get; set; }
        public string DestinationName { get; set; }
        public string DestinationType { get; set; }

        public PropertyMapping(PropertyPair pair)
        {
            SourceName = pair.Source.Name;
            SourceType = pair.Source.ReflectedType.FullName;

            DestinationName = pair.Destination.Name;
            DestinationType = pair.Destination.ReflectedType.FullName;
        }
    }
}