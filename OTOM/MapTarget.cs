using System;

namespace Otom.Core
{
    [Serializable]
    public class MapTarget
    {
        public string AssemblyPath { get; set; }
        public ClassInfo ClassType { get; set; }

        private MapTarget()
        {
        }

        public MapTarget(string assemblyPath, ClassInfo classType)
        {
            AssemblyPath = assemblyPath;
            ClassType = classType;
        }
    }
}
