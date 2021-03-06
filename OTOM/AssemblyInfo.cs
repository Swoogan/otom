﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Otom.Core
{
    public class AssemblyInfo
    {
        private readonly Assembly _assembly;

        public AssemblyInfo(string assemblyPath)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
                throw new ArgumentException("Assembly path is empty", "assemblyPath");

            _assembly = Assembly.LoadFrom(assemblyPath);
        }

        public IList<ClassInfo> GetClasses()
        {
            var classes = from t in _assembly.GetTypes()
                where t.IsClass && !ExcludesFile.Excludes.Contains(t.Name) && !t.Name.StartsWith("<>")
                select new ClassInfo(t);

            return classes.ToList();
        }
    }
}