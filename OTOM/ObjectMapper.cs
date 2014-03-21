using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otom.Core
{
    public class ObjectMapper
    {
        /**********************************
         * MAPPING with class intializers *
         * ********************************/
        public static string Map(List<PropertyMapping> pairs, ClassInfo source, ClassInfo destination, bool mapOpposite)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("public static {0}.{1} Map({2}.{3} {4})\n", destination.Namespace, destination.Name, source.Namespace, source.Name, GetVar(source.Name));
            sb.AppendLine("{");
            sb.AppendFormat("\treturn new {0}.{1} {{\n", destination.Namespace, destination.Name);

            foreach (var p in pairs)
                sb.AppendFormat("\t\t{0} = {1}.{2},\n", p.Destination.Name, GetVar(source.Name), p.Source.Name);

            sb.AppendFormat("\t}};\n");
            sb.AppendLine("}");

            if (!mapOpposite) return sb.ToString();

            sb.AppendLine();

            var secondPairs = new List<PropertyMapping>(pairs.Count);
            secondPairs.AddRange(pairs.Select(pair => new PropertyMapping(pair.Destination, pair.Source)));
            sb.AppendLine(Map(secondPairs, destination, source, false));

            return sb.ToString();
        }

        /*****************************
         * MAPPING WITH AppendFormat *
         * ***************************/
        public static string MapWithFormat(List<PropertyMapping> pairs, ClassInfo source, ClassInfo destination, bool mapOpposite)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("public static {0}.{1} MapFromEntityToModel({2}.{3} {4})\n", destination.Namespace, destination.Name, source.Namespace, source.Name, GetVar(source.Name));
            sb.AppendLine("{");
            sb.AppendFormat("\t{0}.{1} {2} = new {3}.{4}();\n", destination.Namespace, destination.Name, GetVar(destination.Name), destination.Namespace, destination.Name);

            foreach (var p in pairs)
                sb.AppendFormat("\t{0}.{1} = {2}.{3};\n", GetVar(destination.Name), p.Destination.Name, GetVar(source.Name), p.Source.Name);

            sb.AppendFormat("\treturn {0};\n", GetVar(destination.Name));
            sb.AppendLine("}");

            if (!mapOpposite) return sb.ToString();

            sb.AppendLine();

            var secondPairs = new List<PropertyMapping>(pairs.Count);
            secondPairs.AddRange(pairs.Select(pair => new PropertyMapping(pair.Destination, pair.Source)));
            sb.AppendLine(Map(secondPairs, destination, source, false));

            return sb.ToString();
        }

        /********************
         * ORIGINAL MAPPING *
         * ******************/
        //public static String Map(List<PropertyPair> pairs, Type source, Type destination, bool mapOpposite)
        //{
        //    var sb = new StringBuilder();            

        //    sb.AppendLine("public static " + destination.Namespace + "." + destination.Name + " map(" + source.Namespace + "." + source.Name + " " + GetVar(source.Name) + ")");
        //    sb.AppendLine("{");
        //    sb.AppendLine("\t" + destination.Namespace + "." + destination.Name + " " + GetVar(destination.Name) + " = new " + destination.Namespace + "." + destination.Name + "();");
        //    sb.AppendLine();
        //    foreach (var p in pairs)
        //    {
        //        sb.AppendLine("\t" + GetVar(destination.Name) + "." + p.Destination.Name + " = " + GetVar(source.Name) + "." + p.Source.Name + ";");
        //    }
        //    sb.AppendLine();
        //    sb.AppendLine("\t" + "return " + GetVar(destination.Name) + ";");
        //    sb.AppendLine("}");

        //    if (mapOpposite)
        //    {
        //        sb.AppendLine();
        //        sb.AppendLine();

        //        var secondPairs = new List<PropertyPair>(pairs.Count);
        //        secondPairs.AddRange(pairs.Select(pair => new PropertyPair(pair.Destination, pair.Source)));
        //        sb.AppendLine(Map(secondPairs, destination, source, false));
        //    }

        //    return sb.ToString();
        //}

        private static string GetVar(string name)
        {
            return name.Substring(0, 1).ToLower() + (name.Length > 1 ? name.Substring(1) : String.Empty);
        }
    }
}