using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using GqlPlus;

namespace GqlPlus;

public static class RenderPlain
{
  public const int MaxLineLength = 120;

  public static string[] ToPlain(this IGqlpValue model, bool _)
    => model is null ? []
      : [.. WriteStructure(model).RemoveEmpty()];
  public static IGqlpValue FromPlain(this string[] input)
    => ReadStructure(input);

  private static IGqlpValue ReadStructure(IEnumerable<string> lines)
  {
    IEnumerable<IGrouping<LineKey, string>> groups = lines
      .Select(SplitLine)
      .GroupBy(kv => kv.Key, kv => kv.Remain);

    IGqlpValue? result = null;
    List<IGqlpValue> items = [];
    List<KeyValuePair<IGqlpScalar, IGqlpValue>> fields = [];
    string tag = string.Empty;

    foreach (IGrouping<LineKey, string> group in groups) {
      tag = ReadLineGroup(ref result, items, fields, group);
    }

    return items.Count > 0 ? new GqlpList(items, tag)
    : fields.Count > 0 ? new GqlpMap(fields, tag)
    : result is null ? string.IsNullOrWhiteSpace(tag) ? new GqlpUnit() : new GqlpUnit(tag)
    : result;
  }

  private static string ReadLineGroup(
    ref IGqlpValue? result,
    List<IGqlpValue> items,
    List<KeyValuePair<IGqlpScalar, IGqlpValue>> fields,
    IGrouping<LineKey, string> group
  )
  {
    string tag = group.Key.Tag;
    if (group.Key.Type == ':') {
      IGqlpScalar key = ReadValue(group.Key.Key);
      IGqlpValue value = ReadStructure(group);
      fields.Add(new(key, value));
    } else if (group.Key.Type == '.') {
      IGqlpValue value = ReadStructure(group);
      while (items.Count <= group.Key.Index) {
        items.Add(new GqlpUnit(tag));
      }

      items[group.Key.Index!.Value] = value;
    } else if (group.Key.Type == '=') {
      GqlpScalar value = ReadValue(group.First());
      result = ScalarIsEmpty(value)
        ? string.IsNullOrWhiteSpace(value.Tag) ? new GqlpUnit() : new GqlpUnit(value.Tag)
        : value;
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
  private static string[] WriteStructure(IGqlpValue item, string prefix = "")
  {
    if (item is IGqlpScalar scalar && !ScalarIsEmpty(scalar)) {
      StringBuilder sb = new();
      WriteValue(sb, scalar);
      return [prefix + sb.ToString()];
    }

    prefix += item.Tag.Surrounded("[", "]");
    return item switch {
      GqlpList list when list.Items.Count > 0 => WriteList(list.Items, prefix),
      GqlpMap map when map.Entries.Count > 0 => WriteMap(map.Entries, prefix),
      _ => string.IsNullOrWhiteSpace(prefix) ? [] : ["=" + prefix],
    };
  }

  private static string[] WriteList(IReadOnlyList<IGqlpValue> list, string prefix = "")
    => [.. list.SelectMany((item, idx)
      => WriteStructure(item, prefix + $".{idx}"))];

  private static string[] WriteMap(IReadOnlyDictionary<IGqlpScalar, IGqlpValue> map, string prefix = "")
    => [.. map
      .OrderBy(kv => ScalarText(kv.Key), StringComparer.Ordinal)
      .SelectMany(item => {
        StringBuilder sb = new(prefix);
        WriteValue(sb, item.Key, ":");

        return WriteStructure(item.Value, sb.ToString());
      })];

  private static readonly char[] s_quotes = ['"', '\''];
  private static GqlpScalar ReadValue(string line)
  {
    Match tagMatch = s_tag.Match(line);
    string tag = tagMatch.Success ? tagMatch.Groups[1].Value : string.Empty;
    line = line[tagMatch.Length..];

    if (string.IsNullOrEmpty(line)) {
      return new GqlpScalar("", tag);
    } else if (decimal.TryParse(line, out decimal num)) {
      return new GqlpScalar(num, tag);
    } else if (bool.TryParse(line, out bool trueFalse)) {
      return new GqlpScalar(trueFalse, tag);
    } else if (s_quotes.Contains(line[0]) && line[^1] == line[0]) {
      string quote = line[..1];
      string value = line[1..^1].Replace("\\" + quote, quote).Replace("\\\\", "\\");
      return new GqlpScalar(value, tag);
    }

    return new GqlpScalar(line, tag, isIdentifier: line.IsIdentifier());
  }
  private static void WriteValue(StringBuilder sb, IGqlpScalar value, string prefix = "=")
  {
    if (ScalarIsEmpty(value)) {
      return;
    }

    sb.Append(prefix);
    if (!string.IsNullOrWhiteSpace(value.Tag)) {
      sb.Append($"[{value.Tag}]");
    }

    if (value.Kind == GqlpScalarKind.Boolean) {
      sb.Append(value.BooleanValue!.Value.ToString().ToLowerInvariant());
    } else if (value.Kind == GqlpScalarKind.Number) {
      sb.Append($"{value.Number:0.#####}");
    } else if (value.Kind == GqlpScalarKind.Identifier) {
      sb.Append(value.Text);
    } else if (!string.IsNullOrEmpty(value.Text)) {
      sb.Append(value.Text.QuotedIdentifier());
    }
  }

  private static bool ScalarIsEmpty(IGqlpScalar value)
    => (value.Kind is GqlpScalarKind.Text or GqlpScalarKind.Identifier) && string.IsNullOrEmpty(value.Text);

  private static string ScalarText(IGqlpScalar value)
    => value.Kind switch {
      GqlpScalarKind.Boolean => value.BooleanValue!.Value.TrueFalse(),
      GqlpScalarKind.Number => $"{value.Number:0.#####}",
      _ => value.Text ?? "",
    };

  internal record struct LineKey(char Type, string Tag)
  {
    internal string Key { get; init; } = string.Empty;
    internal int? Index { get; init; }
  }
}
