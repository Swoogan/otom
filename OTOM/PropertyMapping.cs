using System;
using System.Reflection;

namespace Otom.Core
{
    [Serializable]
    public class PropertyMapping
    {
        public PropInfo Source { get; set; }
        public PropInfo Destination { get; set; }

        public PropertyMapping(PropertyInfo source, PropertyInfo destination)
        {
            Source = new PropInfo(source.Name, source.DeclaringType);
            Destination = new PropInfo(destination.Name, destination.DeclaringType);
        }

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