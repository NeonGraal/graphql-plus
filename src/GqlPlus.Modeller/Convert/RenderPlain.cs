using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GqlPlus.Convert;

public static class RenderPlain
{
  public const int MaxLineLength = 120;

  public static string[] ToPlain(this Structured model, bool _)
    => model is null ? []
      : [.. WriteStructure(model).RemoveEmpty()];
  public static Structured FromPlain(this string[] input)
    => ReadStructure(input);

  private static Structured ReadStructure(IEnumerable<string> lines)
  {
    IEnumerable<IGrouping<LineKey, string>> groups = lines
      .Select(SplitLine)
      .GroupBy(kv => kv.Key, kv => kv.Remain);

    StructureValue? result = null;
    List<Structured> items = [];
    Dictionary<StructureValue, Structured> fields = [];
    string tag = string.Empty;

    foreach (IGrouping<LineKey, string> group in groups) {
      tag = ReadLineGroup(ref result, items, fields, group);
    }

    return items.Count > 0 ? new(items) { Tag = tag }
    : fields.Count > 0 ? new(fields) { Tag = tag }
    : result is null ? Structured.Empty(tag)
    : new(result);
  }

  private static string ReadLineGroup(ref StructureValue? result, List<Structured> items, Dictionary<StructureValue, Structured> fields, IGrouping<LineKey, string> group)
  {
    string tag = group.Key.Tag;
    if (group.Key.Type == ':') {
      StructureValue key = ReadValue(group.Key.Key);
      Structured value = ReadStructure(group);
      fields[key] = value;
    } else if (group.Key.Type == '.') {
      Structured value = ReadStructure(group);
      while (items.Count <= group.Key.Index) {
        items.Add(Structured.Empty(tag));
      }

      items[group.Key.Index!.Value] = value;
    } else if (group.Key.Type == '=') {
      result = ReadValue(group.First());
    }

    return tag;
  }

  private static readonly Regex s_tag = new(@"^\[([^\]]+)\]", RegexOptions.Compiled);
  private static readonly Regex s_lineKey = new(@"^(:(?<key>(?:\[[^\]]+\])?[^:\.=[]+)|\.(?<index>\d+)|=)", RegexOptions.Compiled);
  private static (LineKey Key, string Remain) SplitLine(string line)
  {
    Match tagMatch = s_tag.Match(line);
    string tag = tagMatch.Success ? tagMatch.Groups[1].Value : string.Empty;
    line = line[tagMatch.Length..];
    Match match = s_lineKey.Match(line);
    if (!match.Success) {
      return (new('\0', tag), line);
    }

    line = line[match.Length..];
    LineKey result = new(match.Value[0], tag);
    if (result.Type == ':') {
      string key = match.Groups["key"].Value;
      result = result with { Key = key };
    } else if (result.Type == '.') {
      int? index = int.Parse(match.Groups["index"].Value, CultureInfo.InvariantCulture);
      result = result with { Index = index };
    }

    return (result, line);
  }
  private static string[] WriteStructure(Structured item, string prefix = "")
  {
    if (item.Value?.IsEmpty == false) {
      StringBuilder sb = new();
      WriteValue(sb, item.Value);
      return [prefix + sb.ToString()];
    }

    prefix += item.Tag.Surrounded("[", "]");
    string[] result = [];

    if (item.List.Any()) {
      return WriteList(item.List, prefix);
    }

    if (item.Map.Any()) {
      return WriteMap(item.Map, prefix);
    }

    return string.IsNullOrWhiteSpace(prefix) ? [] : ["=" + prefix];
  }

  private static string[] WriteList(IList<Structured> list, string prefix = "")
    => [.. list.SelectMany((item, idx)
      => WriteStructure(item, prefix + $".{idx}"))];

  private static string[] WriteMap(ComplexValue<StructureValue, Structured>.IDict map, string prefix = "")
    => [.. map
      .OrderBy(kv => kv.Key.AsString, StringComparer.Ordinal)
      .SelectMany(item => {
        StringBuilder sb = new(prefix);
        WriteValue(sb, item.Key, ":");

        return WriteStructure(item.Value, sb.ToString());
      })];

  private static readonly char[] s_quotes = ['"', '\''];
  private static StructureValue ReadValue(string line)
  {
    Match tagMatch = s_tag.Match(line);
    string tag = tagMatch.Success ? tagMatch.Groups[1].Value : string.Empty;
    line = line[tagMatch.Length..];

    if (string.IsNullOrEmpty(line)) {
      return StructureValue.Empty(tag);
    } else if (decimal.TryParse(line, out decimal num)) {
      return new(num, tag);
    } else if (bool.TryParse(line, out bool trueFalse)) {
      return new StructureValue(trueFalse, tag);
    } else if (s_quotes.Contains(line[0]) && line[^1] == line[0]) {
      string quote = line[0..0];
      string value = line[1..^1].Replace("\\" + quote, quote).Replace("\\\\", "\\");
      return new(value, tag);
    }

    return new(line, tag);
  }
  private static void WriteValue(StringBuilder sb, StructureValue value, string prefix = "=")
  {
    if (value is null || value.IsEmpty) {
      return;
    }

    sb.Append(prefix);
    if (!string.IsNullOrWhiteSpace(value.Tag)) {
      sb.Append($"[{value.Tag}]");
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

  internal record struct LineKey(char Type, string Tag)
  {
    internal string Key { get; init; } = string.Empty;
    internal int? Index { get; init; }
  }
}
