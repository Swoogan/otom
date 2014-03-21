using System;
using System.Reflection;

namespace OTOM
{
    [Serializable]
    public class PropertyPair
    {
        public PropertyInfo Source { get; set; }
        public PropertyInfo Destination { get; set; }

        public PropertyPair()
        {
        }

        public PropertyPair(PropertyInfo source, PropertyInfo destination)
        {
            Source = source;
            Destination = destination;
        }

        public override string ToString()
        {
            return Source.Name + " --> " + Destination.Name;
        }
    }
}
