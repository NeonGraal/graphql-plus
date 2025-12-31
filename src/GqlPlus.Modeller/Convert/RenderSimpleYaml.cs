using System.Text;

namespace GqlPlus.Convert;

public static class RenderSimpleYaml
{
  public const int MaxLineLength = 120;

  public static string[] ToSimpleYaml(this Structured model, bool _)
    => model is null || model.IsEmpty ? []
      : [.. WriteStructure(model).Where(s => !string.IsNullOrWhiteSpace(s))];

  private static string[] WriteStructure(Structured item)
  {
    if (item.Value?.IsEmpty == false) {
      StringBuilder sb = new();
      WriteValue(sb, item.Value);
      return [sb.ToString()];
    }

    string[] result = [];

    if (item.List.Any()) {
      result = [.. WriteList(item.List)];
    }

    if (item.Map.Any()) {
      result = [.. WriteMap(item.Tag, item.Map)];
    }

    return result;
  }

  private static IEnumerable<string> WriteList(IList<Structured> list)
  {
    if (list.Count == 0) {
      yield break;
    }

    yield return "";
    foreach (Structured item in list) {
      foreach (string line in WriteItem(item, "-")) {
        yield return line;
      }
    }
  }

  private static IEnumerable<string> WriteItem(Structured item, string prefix)
  {
    List<string> newLines = [.. WriteStructure(item)];
    if (newLines.Count == 0) {
      yield break;
    }

    string first = newLines[0];
    if (first.TrimStart().StartsWith("!", StringComparison.Ordinal) || newLines.Count == 1) {
      newLines.RemoveAt(0);
      yield return prefix + " " + first;
      if (newLines.Count == 0) {
        yield break;
      }
    } else {
      yield return prefix;
    }

    foreach (string line in newLines) {
      yield return "  " + line;
    }
  }

  private static IEnumerable<string> WriteMap(string tag, ComplexValue<StructureValue, Structured>.IDict map)
  {
    if (map.Count == 0) {
      yield break;
    }

    if (!string.IsNullOrWhiteSpace(tag)) {
      yield return $"!{tag}";
    } else {
      yield return "";
    }

    foreach (KeyValuePair<StructureValue, Structured> item in map.OrderBy(kv => kv.Key.AsString, StringComparer.Ordinal)) {
      StringBuilder sb = new("");
      WriteValue(sb, item.Key);
      sb.Append(':');

      foreach (string line in WriteItem(item.Value, sb.ToString())) {
        yield return line;
      }
    }
  }

  private static void WriteValue(StringBuilder sb, StructureValue value)
  {
    if (value is null || value.IsEmpty) {
      return;
    }

    if (!string.IsNullOrWhiteSpace(value.Tag)) {
      sb.Append($"!{value.Tag} ");
    }

    if (value.Boolean is not null) {
      sb.Append(value.Boolean.ToString().ToLowerInvariant());
    } else if (value.Number is not null) {
      sb.Append($"{value.Number:0.#####}");
    } else if (!string.IsNullOrWhiteSpace(value.Identifier)) {
      sb.Append(value.Identifier);
    } else if (!string.IsNullOrEmpty(value.Text)) {
      sb.Append(value.Text.QuotedIdentifier());
    }
  }
}
