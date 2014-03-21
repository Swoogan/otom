using System;
using System.Reflection;

namespace Otom.Core
{
    public class ClassInfo
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public PropertyInfo[] Properties { get; set; }

        public ClassInfo(Type type)
        {
            Name = type.Name;
            Namespace = type.Namespace;
            Properties = type.GetProperties();
        }
    }
}
