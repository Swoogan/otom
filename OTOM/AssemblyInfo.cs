using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Otom.Core
{
    public class AssemblyInfo
    {
        private readonly Assembly _assembly;

        public string Location
        {
            get { return _assembly.Location; }
        }

        public AssemblyInfo(string assemblyPath)
        {
            _assembly = Assembly.LoadFrom(assemblyPath);
        }

        public IList<ClassInfo> GetClasses()
        {
            var classes = from t in _assembly.GetTypes()
                where t.IsClass && !ExcludesFile.Excludes.Contains(t.Name) && !t.Name.StartsWith("<>")
                select new ClassInfo(t);

            return classes.ToList();
        }

        public Type GetType(string typeName)
        {
            return _assembly.GetType(typeName);
        }
    }
}