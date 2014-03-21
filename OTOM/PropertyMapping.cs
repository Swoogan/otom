using System;

namespace Otom.Core
{
    [Serializable]
    public class PropertyMapping
    {
        public PropInfo Source { get; set; }
        public PropInfo Destination { get; set; }

        public PropertyMapping(PropInfo source, PropInfo destination)
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