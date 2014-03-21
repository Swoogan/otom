using System;

namespace Otom.Core
{
    public class PropInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string FullName { get; set; }

        public PropInfo(string name, Type type)
        {
            Name = name;
            Type = type.Name;
            FullName = type.FullName;
        }
    }
}
