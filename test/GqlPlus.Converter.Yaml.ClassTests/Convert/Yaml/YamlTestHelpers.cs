namespace GqlPlus.Convert.Yaml;

internal static class YamlTestHelpers
{
  internal static IConvertTestsBase Full { get; } = new YamlConverters(false);
  internal static IConvertTestsBase Wrapped { get; } = new YamlConverters(true);

  internal static string[] Tagged(this string tag, string value)
    => [$"!{tag} {value}"];

  internal static string[] FlowOr<T>(this IEnumerable<T> list, Func<IEnumerable<T>, string> flowMap, Func<IEnumerable<T>, string[]> isMap)
  {
    string flow = flowMap(list);

    return flow.Length < RenderYaml.BestWidth * 20 ? [flow] : isMap(list);
  }

  internal static string[] FlowList(this string[] value, string valuePrefix = "", string listPrefix = "", string indent = "")
    => value.FlowList(v => [valuePrefix + v], listPrefix, indent);

  internal static string[] FlowList<T>(this T[] value, Func<T?, string[]> mapper, string listPrefix = "", string indent = "")
    => value.FlowOr(
      f => f.Surround(listPrefix + "[", "]", v => mapper(v).Joined(""), ", "),
      i => i.IsList(v => v.BlockFirst(mapper, indent + "-"), listPrefix));

  internal static string[] FlowMap(this MapPair<string>[] list, string mapPrefix = "", string keyPrefix = "", string valuePrefix = "", string indent = "")
    => list.FlowMap(v => [valuePrefix + v], mapPrefix, keyPrefix, indent);

  internal static string[] FlowMap<T>(this MapPair<T>[] list, Func<T?, string[]> mapper, string mapPrefix = "", string keyPrefix = "", string indent = "")
    => list.OrderBy(kv => kv.Key, StringComparer.Ordinal).FlowOr(
      f => mapPrefix + f.Surround("{", "}", v => keyPrefix + v.Key + ": " + mapper(v.Value).Joined(""), ", "),
      i => i.IsMap(v => mapper(v), indent + keyPrefix, mapPrefix));

  internal static string[] BlockList(this string[] value, string itemPrefix, string listPrefix = "")
    => value.IsList(v => [itemPrefix + v], listPrefix);

  internal static string[] BlockList<T>(this T[] value, Func<T?, string[]> mapper, string listPrefix = "")
    => value.IsList(mapper, listPrefix);

  internal static string[] BlockMap(this MapPair<string>[] list, string keyPrefix = "", string valuePrefix = "", string mapPrefix = "")
    => list.BlockMap(v => [valuePrefix + v], keyPrefix, mapPrefix);

  internal static string[] BlockMap<T>(this MapPair<T>[] list, Func<T?, string[]> mapper, string keyPrefix = "", string mapPrefix = "")
    => list.OrderBy(kv => kv.Key, StringComparer.Ordinal).IsMap(mapper, keyPrefix, mapPrefix);

  private static string[] IsList<T>(this IEnumerable<T> list, Func<T?, string[]> mapper, string listPrefix)
    => [.. list
      .SelectMany(mapper)
      .Prepend(listPrefix)
      .RemoveEmpty()];

  private static string[] IsMap<T>(this IEnumerable<MapPair<T>> map, Func<T?, string[]> mapper, string keyPrefix, string mapPrefix)
    => [.. map
      .SelectMany(v => v.Value.BlockFirst(mapper,  keyPrefix + v.Key + ":"))
      .Prepend(mapPrefix)
      .RemoveEmpty()];

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
      => input.FromYaml();
    public string[] ConvertTo(Structured model)
      => model.ToYaml(wrapped).ToLines();
  }
}
