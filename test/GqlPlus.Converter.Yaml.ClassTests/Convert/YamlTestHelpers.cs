using Xunit.Sdk;

namespace GqlPlus.Convert;

internal static class YamlTestHelpers
{
  internal static IConvertTestsBase Full { get; } = new YamlConverters(false);
  internal static IConvertTestsBase Wrapped { get; } = new YamlConverters(true);

  internal static string[] WithFullTag(this string tag, string value)
    => [$"!{tag} {value}"];
  internal static string[] WithWrappedTag(this string tag, string value)
    => [$"!{tag} {value}"];

  internal static string[] FlowOr<T>(this IEnumerable<T> list, Func<IEnumerable<T>, string> flowMap, Func<IEnumerable<T>, string[]> isMap)
  {
    string flow = flowMap(list);

    return flow.Length < RenderYaml.BestWidth * 20 ? [flow] : isMap(list);
  }

  internal static string[] FlowList(this string[] value, string valuePrefix = "", string indent = "")
    => value.FlowList(v => [valuePrefix + v], indent);

  internal static string[] FlowList<T>(this T[] value, Func<T?, string[]> mapper, string indent = "")
    => value.FlowOr(
      f => f.Surround("[", "]", v => mapper(v).Joined(""), ", "),
      i => i.IsList(v => v.BlockFirst(mapper, indent + "-")));

  internal static string[] FlowMap(this MapPair<string>[] list, string mapPrefix = "", string valuePrefix = "", string indent = "")
    => list.FlowMap(v => [valuePrefix + v], mapPrefix, indent);

  internal static string[] FlowMap<T>(this MapPair<T>[] list, Func<T?, string[]> mapper, string mapPrefix = "", string indent = "")
    => list.OrderBy(kv => kv.Key, StringComparer.Ordinal).FlowOr(
      f => mapPrefix + f.Surround("{", "}", v => v.Key + ": " + mapper(v.Value).Joined(""), ", "),
      i => i.IsMap(v => mapper(v), indent, mapPrefix));

  internal static string[] BlockList(this string[] value, string prefix)
    => value.IsList(v => [prefix + v]);

  internal static string[] BlockList<T>(this T[] value, Func<T?, string[]> mapper)
    => value.IsList(mapper);

  internal static string[] BlockMap(this MapPair<string>[] list, string keyPrefix = "", string valuePrefix = "")
    => list.BlockMap(v => [valuePrefix + v], keyPrefix);

  internal static string[] BlockMap<T>(this MapPair<T>[] list, Func<T?, string[]> mapper, string keyPrefix = "")
    => list.OrderBy(kv => kv.Key, StringComparer.Ordinal).IsMap(mapper, keyPrefix);

  private static string[] IsList<T>(this IEnumerable<T> value, Func<T?, string[]> mapper)
    => [.. value.SelectMany(mapper).Where(s => !string.IsNullOrWhiteSpace(s))];

  private static string[] IsMap<T>(this IEnumerable<MapPair<T>> list, Func<T?, string[]> mapper, string keyPrefix = "", string mapPrefix = "")
    => [.. list
      .SelectMany(v => v.Value.BlockFirst(mapper,  keyPrefix + v.Key + ":"))
      .Prepend(mapPrefix)
      .Where(s => !string.IsNullOrWhiteSpace(s))];

  private static string[] BlockFirst<T>(this T value, Func<T?, string[]> mapper, string prefix)
  {
    string[] item = mapper(value);
    if (item.Length == 0) {
      return [];
    }

    string first = item[0];
    if (item.Length == 1) {
      return [prefix + " " + first];
    } else if (first.StartsWith('!')) {
      return [prefix + " " + first, .. item[1..]];
    } else {
      return [prefix, .. item];
    }
  }

  private sealed class YamlConverters(
    bool wrapped
  ) : IConvertTestsBase
  {
    public Structured ConvertFrom(string[] input)
      => throw SkipException.ForSkip("Yaml Deserialize not implemented yet");
    public string[] ConvertTo(Structured model)
      => model.ToYaml(wrapped).ToLines();
  }
}
