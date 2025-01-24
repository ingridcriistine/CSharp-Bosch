using System.Collections;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Converter;

public static class Converter
{
    // public static Task<string> ToJsonAsync<T>(this T obj)
    // {

    // }

    public static string ToJson<T>(this T obj)
    {
        var sb = new StringBuilder();
        sb.AppendLine("{");
        toJson(obj, sb, 0);
        sb.AppendLine("}");
        return sb.ToString();
    }

    private static void toJson<T>(this T obj, StringBuilder sb, int tab)
    {
        var objeto = obj.GetType();

        // Console.WriteLine(objeto);

        var props = objeto.GetProperties();

        foreach (var item in props)
        {
            var propertyName = item.Name;
            // Console.WriteLine($"Atributo: {propertyName}");

            var propertyValue = item.GetValue(obj);
            // Console.WriteLine($"Valor: {propertyValue}");
            
            if (propertyValue is IEnumerable e && item.PropertyType != typeof(string)) {
                ident(sb, tab+1);
                sb.Append($" '{propertyName}' : " + "[");
                
                foreach (var itemList in e) {
                    ident(sb, tab+1);
                    sb.AppendLine("{");
                    if (itemList.GetType().IsClass && itemList.GetType() != typeof(string)) {
                        toJson(itemList, sb, tab+1);
                        continue;
                    }

                    ident(sb, tab-1);
                    sb.AppendLine($"\t'{propertyName}' : '{itemList.ToString()}',");
                    ident(sb, tab+1);
                }
 
                sb.AppendLine("]");
            }

            else if (item.PropertyType.IsClass && item.PropertyType != typeof(string)) {
                toJson(propertyValue, sb, tab+1);
            }

            else
            {
                sb.AppendLine($"\t'{propertyName}' : '{propertyValue}',");
            }
        }
    }

    public static void ident(StringBuilder sb, int tab) {
        sb.Append(new string('\t', tab));
    }
}