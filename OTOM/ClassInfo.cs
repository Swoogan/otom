using System;
using System.Collections.Generic;

namespace Otom.Core
{
    [Serializable]
    public class ClassInfo
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public List<string> Properties { get; set; }

        private ClassInfo()
        {
        }

        public ClassInfo(Type type)
        {
            Properties = new List<string>();
            Namespace = type.Namespace;
            Name = type.Name;

            foreach (var property in type.GetProperties())
                Properties.Add(property.Name);
        }
    }
}
