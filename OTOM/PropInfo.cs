
using System;
using System.Reflection;

namespace Otom.Core
{
    public class PropInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string FullName { get; set; }

        public PropInfo(PropertyInfo info)
        {
            Name = info.Name;
            Type = info.DeclaringType.Name;
            FullName = info.DeclaringType.FullName;
        }

        public PropertyInfo GetPropertyInfo(Assembly assembly)
        {
            var type = assembly.GetType(Type);
            var property = type.GetProperty(Name);

            if (property == null)
                throw new ArgumentException("Unable to find property [" + Name + "] in type [" + Type + "]");

            return property;
        }
    }
}
