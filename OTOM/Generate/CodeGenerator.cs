using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otom.Core.Generate
{
    public static class CodeGenerator
    {
        public static string Generate(GenerateInfo info)
        {
            var result = Map(info.Pairs, info.SourceClass, info.DestinationClass, DirectionEnum.Forward);
            
            if (info.Reverse)
                result += Map(info.Pairs, info.DestinationClass, info.SourceClass, DirectionEnum.Backward);

            return result;
        }

        private static string Map(IEnumerable<PropertyPair> pairs, ClassInfo sourceClass, ClassInfo destClass, DirectionEnum direction)
        {
            var sb = new StringBuilder();
            var parameterName = CreateParameterName(sourceClass.Name);

            sb.AppendFormat("public static {0}.{1} Map({2}.{3} {4})\n", destClass.Namespace, destClass.Name, sourceClass.Namespace, sourceClass.Name, parameterName);
            sb.AppendLine("{");
            sb.AppendFormat("\treturn new {0}.{1} {{\n", destClass.Namespace, destClass.Name);

            var format = (direction == DirectionEnum.Forward) ? "\t\t{0} = {1}.{2},\n" : "\t\t{2} = {1}.{0},\n";

            foreach (var pair in pairs)
                sb.AppendFormat(format, pair.Destination, parameterName, pair.Source);

            sb.AppendFormat("\t}};\n");
            sb.AppendLine("}\n");

            return sb.ToString();
        }

        /*****************************
         * MAPPING WITH AppendFormat *
         * ***************************/
        private static string MapWithFormat(List<PropertyPair> pairs, ClassInfo sourceClass, ClassInfo destClass, bool mapOpposite)
        {
            var sb = new StringBuilder();

            var sourceName = CreateParameterName(sourceClass.Name);
            var destinationName = CreateParameterName(destClass.Name);

            sb.AppendFormat("public static {0}.{1} MapFromEntityToModel({2}.{3} {4})\n", destClass.Namespace, destClass.Name, sourceClass.Namespace, sourceClass.Name, sourceName);
            sb.AppendLine("{");
            sb.AppendFormat("\t{0}.{1} {2} = new {3}.{4}();\n", destClass.Namespace, destClass.Name, destinationName, destClass.Namespace, destClass.Name);

            foreach (var p in pairs)
                sb.AppendFormat("\t{0}.{1} = {2}.{3};\n", destinationName, p.Destination, sourceName, p.Source);

            sb.AppendFormat("\treturn {0};\n", destinationName);
            sb.AppendLine("}");

            if (!mapOpposite) return sb.ToString();

            sb.AppendLine();

            var secondPairs = new List<PropertyPair>(pairs.Count);
            secondPairs.AddRange(pairs.Select(pair => new PropertyPair(pair.Destination, pair.Source)));
            sb.AppendLine(MapWithFormat(secondPairs, destClass, sourceClass, false));

            return sb.ToString();
        }

        private static string CreateParameterName(string name)
        {
            return name.Substring(0, 1).ToLower() + (name.Length > 1 ? name.Substring(1) : String.Empty);
        }
    }
}