using System;

namespace Otom.Core
{
    [Serializable]
    public class PropertyPair
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        private PropertyPair()
        {
        }

        public PropertyPair(string source, string destination)
        {
            Source = source;
            Destination = destination;
        }

        public override string ToString()
        {
            return Source + " --> " + Destination;
        }
    }
}