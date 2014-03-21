
namespace Otom.Core.Generate
{
    public class ClassInfo
    {
        public string Name { get; set; }
        public string Namespace { get; set; }

        public ClassInfo(Core.ClassInfo info)
        {
            Name = info.Name;
            Namespace = info.Namespace;
        }
    }
}
