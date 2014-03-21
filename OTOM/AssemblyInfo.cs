using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Otom.Core
{
    public class AssemblyInfo
    {
        //Hack: Cheap temporary hack
        private readonly List<string> _excludes = new List<string> { "Codes", "CodeKeys", "CodeKeyGuids", "Invoice", "InvoiceDetail", "InvoiceHeader" };

        private readonly Assembly _assembly;

        public AssemblyInfo(string assemblyPath)
        {
            _assembly = Assembly.LoadFrom(assemblyPath);
        }

        public IEnumerable<Type> GetClassesFromAssembly()
        {
            var types = _assembly.GetTypes();
            return types.Where(type => type.IsClass && !_excludes.Contains(type.Name) && !type.Name.StartsWith("<>"));
        }

        public PropertyInfo GetPropertyByName(string typeName, string propertyName)
        {
            var type = _assembly.GetType(typeName);
            var property = type.GetProperty(propertyName);
            
            if (property == null)
                throw new ArgumentException("Unable to find property [" + propertyName + "] in type [" + typeName + "]");

            return property;
        }

        public Type GetTypeByName(string typeName)
        {
            return _assembly.GetType(typeName);
        }
    }
}