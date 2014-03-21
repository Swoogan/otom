using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OTOM
{
    public class ClassInfo
    {
        //Hack: Cheap temporary hack
        private readonly List<string> Excludes = new List<string> { "Codes", "CodeKeys", "CodeKeyGuids", "Invoice", "InvoiceDetail", "InvoiceHeader" };

        private readonly Assembly _assembly;

        public ClassInfo(string assemblyPath)
        {
            _assembly = Assembly.LoadFrom(assemblyPath);
        }

        public IEnumerable<Type> GetTypesFromAssembly()
        {
            var types = _assembly.GetTypes();
            return types.Where(type => !Excludes.Contains(type.Name) && !type.Name.StartsWith("<>"));
        }

        public PropertyInfo GetPropertyByName(string typeName, string propertyName)
        {
            var objectType = GetTypeByName(typeName);
            objectType.GetProperty(propertyName)

            throw new ArguementExecption("Unable to find property [" + propertyName + "] in type [" + typeName + "]");
        }

        public Type GetTypeByName(string type)
        {
            return _assembly.GetType(type);
        }
    }
}