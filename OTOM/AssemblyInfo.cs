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

        public AssemblyInfo(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IList<ClassInfo> GetClasses()
        {
            var classes = from t in _assembly.GetTypes()
                where t.IsClass && !_excludes.Contains(t.Name) && !t.Name.StartsWith("<>")
                select new ClassInfo(t);

            return classes.ToList();
        }
    }
}