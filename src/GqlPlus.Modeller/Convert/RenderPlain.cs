using System.Text;

namespace GqlPlus.Convert;

public static class RenderPlain
{
  public const int MaxLineLength = 120;

  public static string[] ToPlain(this Structured model, bool _)
    => model is null || model.IsEmpty ? []
      : [.. WriteStructure(model).RemoveEmpty()];
  public static Structured FromPlain(this string[] input)
    => throw new NotImplementedException();

  private static string[] WriteStructure(Structured item, string prefix = "")
  {
    if (item.Value?.IsEmpty == false) {
      StringBuilder sb = new();
      WriteValue(sb, item.Value);
      return [prefix + sb.ToString()];
    }

    prefix += item.Tag.Prefixed("[").Suffixed("]");
    string[] result = [];

    if (item.List.Any()) {
      return WriteList(item.List, prefix);
    }

    if (item.Map.Any()) {
      return WriteMap(item.Map, prefix);
    }

    return [];
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
}
