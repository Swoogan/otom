using System;
using System.Collections.Generic;

namespace Otom.Core
{
    public class ClassInfo
    {
        public string Namespace { get; private set; }
        public string Name { get; private set; }
        public List<PropInfo> Properties { get; private set; }

        public ClassInfo(Type type)
        {
            Name = type.Name;
            Namespace = type.Namespace;

            Properties = new List<PropInfo>();
            foreach (var property in type.GetProperties())
                Properties.Add(new PropInfo(property.Name, type));
        }
    }
}
