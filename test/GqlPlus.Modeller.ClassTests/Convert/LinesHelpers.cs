namespace GqlPlus.Convert;

internal static class LinesHelpers
{
  internal static Structured AsMap<T>(this MapPair<T>[] value, string tag, Func<T, Structured> mapper, bool flow = false)
    => value.ToMap(k => k.Key, v => mapper(v.Value)).Encode(tag, flow);

  internal static string WithLine(this string value, bool always = true)
    => always | value.Length > 0 ? value == Environment.NewLine ? value : value + Environment.NewLine : "";

  internal static string WithSpace(this string value)
    => value + (string.IsNullOrWhiteSpace(value) ? "" : " ");

  internal static bool HasLine(this string value)
    => value.Contains(Environment.NewLine, StringComparison.Ordinal);

  internal static string FlowOr<T>(this T[] list, Func<T[], string> flowMap, Func<T[], string> isMap)
  {
    string flow = flowMap(list);

    return flow.Length <= RenderLines.MaxLineLength ? flow : isMap(list);
  }

  internal static string FlowList(this string[] value, string valuePrefix = "", string indent = "")
    => value.FlowList(v => valuePrefix + v, indent);

  internal static string FlowList<T>(this T[] value, Func<T?, string> mapper, string indent = "")
    => FlowOr(value,
      f => f.Surround("[", "]", mapper, ","),
      i => i.IsList(v => {
        string item = mapper(v);
        if (!item.StartsWith('!') && item.HasLine()) {
          return indent + "-".WithLine() + item;
        } else {
          return indent + "- " + item;
        }
      }));

  internal static string FlowMap(this MapPair<string>[] list, string mapPrefix = "", string valuePrefix = "", string indent = "")
    => list.FlowMap((p, v) => p + valuePrefix + v, mapPrefix, indent);

  internal static string FlowMap<T>(this MapPair<T>[] list, Func<string, T, string> mapper, string mapPrefix = "", string indent = "")
    => FlowOr([.. list.OrderBy(kv => kv.Key, StringComparer.Ordinal)],
      f => mapPrefix + f.Surround("{", "}", v => mapper(v.Key + ":", v.Value), ","),
      i => mapPrefix.WithLine(false) + i.IsMap(v => mapper(" ", v), indent));

  internal static string IsList(this string[] value, string prefix)
    => value.IsList(v => prefix + v);

  internal static string IsList<T>(this T[] value, Func<T?, string> mapper)
    => value.Joined(mapper, Environment.NewLine);

  internal static string IsMap(this MapPair<string>[] list, string keyPrefix, string valuePrefix)
    => list.IsMap(v => valuePrefix + v, keyPrefix);

  internal static string IsMap<T>(this MapPair<T>[] list, Func<T, string> mapper, string keyPrefix = "")
    => list.OrderBy(kv => kv.Key, StringComparer.Ordinal).Joined(v => keyPrefix + v.Key + ":" + mapper(v.Value), Environment.NewLine);
}
