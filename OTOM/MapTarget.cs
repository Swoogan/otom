using System;

namespace Otom.Core
{
    [Serializable]
    public class MapTarget
    {
        public string AssemblyPath { get; private set; }
        public ClassInfo ClassType { get; private set; }

        public MapTarget(string assemblyPath, ClassInfo classType)
        {
            AssemblyPath = assemblyPath;
            ClassType = classType;
        }
    }
}
