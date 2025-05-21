namespace GqlPlus.Convert;

internal static class LinesHelpers
{
  internal static Structured AsMap<T>(this MapPair<T>[] value, string tag, Func<T, Structured> mapper, bool flow = false)
    => value.ToMap(k => k.Key, v => mapper(v.Value)).Render(tag, flow);

  internal static string IsLine(this string value, bool always = true)
    => always | value.Length > 0 ? value + Environment.NewLine : "";

  internal static string FlowOr<T>(this T[] list, Func<T[], string> flowMap, Func<T[], string> isMap)
  {
    string flow = flowMap(list);

    return flow.Length < RenderLines.MaxLineLength ? flow : isMap(list);
  }

  internal static string FlowList(this string[] value, string valuePrefix = "")
    => value.FlowList(v => valuePrefix + v);

  internal static string FlowList<T>(this T[] value, Func<T?, string> mapper)
    => FlowOr(value,
      f => f.Surround("[", "]", mapper, ","),
      i => i.IsList(v => "- " + mapper(v)));

  internal static string FlowMap(this MapPair<string>[] list, string mapPrefix = "", string valuePrefix = "")
    => list.FlowMap(v => valuePrefix + v, mapPrefix, valuePrefix);

  internal static string FlowMap<T>(this MapPair<T>[] list, Func<T, string> mapper, string mapPrefix = "", string valuePrefix = "")
    => FlowOr(list,
      f => mapPrefix + f.OrderBy(kv => kv.Key, StringComparer.Ordinal).Surround("{", "}", v => v.Key + ":" + mapper(v.Value), ","),
      i => mapPrefix.IsLine(false) + i.IsMap(valuePrefix, v => " " + mapper(v)));

  internal static string IsList(this string[] value, string prefix)
    => value.IsList(v => prefix + v);

  internal static string IsList<T>(this T[] value, Func<T?, string> mapper)
    => value.Joined(mapper, Environment.NewLine);

  internal static string IsMap(this MapPair<string>[] list, string keyPrefix, string valuePrefix)
    => list.IsMap(keyPrefix, v => valuePrefix + v);

  internal static string IsMap<T>(this MapPair<T>[] list, string keyPrefix, Func<T, string> mapper)
    => list.OrderBy(kv => kv.Key, StringComparer.Ordinal).Joined(v => keyPrefix + v.Key + ":" + mapper(v.Value), Environment.NewLine);
}
