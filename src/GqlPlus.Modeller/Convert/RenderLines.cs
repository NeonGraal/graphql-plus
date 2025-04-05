using System.Text;
using GqlPlus.Ast;

namespace GqlPlus.Convert;
public static class RenderLines
{
  public static string ToLines(this Structured model, bool _)
  {
    if (model is null || model.IsEmpty) {
      return string.Empty;
    }

    StringBuilder sb = new();
    WriteStructure(sb, model, 0);
    return sb.ToString();
  }

  private static void WriteStructure(StringBuilder sb, Structured item, int indent)
  {
    if (item.Flow) {
      if (item.List.Any() && item.List.All(v => v.Value is not null)) {
        WriteFlowList(sb, item.Tag, item.List, indent);
        return;
      }

      if (item.Map.Any() && item.Map.Values.All(v => v.Value is not null)) {
        WriteFlowMap(sb, item.Tag, item.Map, indent);
        return;
      }
    }

    if (item.Value?.IsEmpty == false) {
      WriteValue(sb, item.Value, Environment.NewLine, indent);
      return;
    }

    if (item.List.Any()) {
      WriteList(sb, item.Tag, item.List, indent);
      return;
    }

    if (item.Map.Any()) {
      WriteMap(sb, item.Tag, item.Map, indent);
    }
  }

  private static void WriteFlowList(StringBuilder sb, string tag, IList<Structured> list, int indent)
  {
    string prefix = " [";
    if (!string.IsNullOrWhiteSpace(tag)) {
      if (indent > 0) {
        sb.Append(' ');
      }

      sb.Append($"!{tag}");
    } else if (indent < 1) {
      prefix = "[";
    }

    foreach (Structured item in list) {
      sb.Append(prefix);
      WriteValue(sb, item.Value!, "", 0);
      prefix = ",";
    }

    sb.AppendLine("]");
  }

  private static void WriteFlowMap(StringBuilder sb, string tag, Structured<StructureValue, Structured>.IDict map, int indent)
  {
    string prefix = " {";
    if (!string.IsNullOrWhiteSpace(tag)) {
      if (indent > 0) {
        sb.Append(' ');
      }
      sb.Append($"!{tag}");
    } else if (indent < 1) {
      prefix = "{";
    }

    foreach (KeyValuePair<StructureValue, Structured> item in map.OrderBy(kv => kv.Key.AsString)) {
      sb.Append(prefix);
      WriteValue(sb, item.Key, ":", 0);
      WriteValue(sb, item.Value.Value!, "", 0);
      prefix = ",";
    }

    sb.AppendLine("}");
  }

  private static void WriteList(StringBuilder sb, string tag, IList<Structured> list, int indent)
  {
    if (!string.IsNullOrWhiteSpace(tag)) {
      if (indent > 0) {
        sb.Append(' ');
      }

      sb.AppendLine($"!{tag}");
    } else if (indent > 0) {
      sb.AppendLine();
    }

    string prefix = new string(' ', indent * 2) + "-";
    foreach (Structured item in list) {
      sb.Append(prefix);
      WriteStructure(sb, item, indent + 1);
    }
  }

  private static void WriteMap(StringBuilder sb, string tag, Structured<StructureValue, Structured>.IDict map, int indent)
  {
    string prefix = "";

    if (!string.IsNullOrWhiteSpace(tag)) {
      if (indent > 0) {
        sb.Append(' ');
        prefix = new(' ', indent * 2 - 1);
      }

      sb.AppendLine($"!{tag}");
    } else if (indent > 0) {
      sb.AppendLine();
      prefix = new(' ', indent * 2 - 1);
    }

    foreach (KeyValuePair<StructureValue, Structured> item in map.OrderBy(kv => kv.Key.AsString)) {
      sb.Append(prefix);
      WriteValue(sb, item.Key, ":", indent);
      WriteStructure(sb, item.Value, indent + 1);
    }
  }

  private static char[] s_special = ['{', '}', '[', ']', '&', '*', '#', '?', '|', '-', '<', '>', '=', '!', '%', '@', ':', '`', ','];

  private static void WriteValue(StringBuilder sb, StructureValue value, string suffix, int indent)
  {
    if (value is null || value.IsEmpty) {
      return;
    }

    if (indent > 0) {
      sb.Append(' ');
    }

    if (!string.IsNullOrWhiteSpace(value.Tag)) {
      sb.Append($"!{value.Tag} ");
    }

    if (value.Boolean is not null) {
      sb.Append(value.Boolean.ToString().ToLowerInvariant());
    } else if (value.Number is not null) {
      sb.Append($"{value.Number:0.#####}");
    } else if (!string.IsNullOrWhiteSpace(value.Identifier)) {
      if (value.Identifier.Intersect(s_special).Any()) {
        sb.Append(value.Identifier.Quoted("'"));
      } else {
        sb.Append(value.Identifier);
      }
    } else if (!string.IsNullOrEmpty(value.Text)) {
      sb.Append(value.Text.Quoted("'"));
    }

    sb.Append(suffix);
  }
}
