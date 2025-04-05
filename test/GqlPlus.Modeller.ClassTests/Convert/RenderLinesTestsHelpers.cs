﻿using GqlPlus.Structures;

namespace GqlPlus.Convert;

internal static class RenderLinesTestsHelpers
{
  internal static Structured AsMap<T>(this MapPair<T>[] value, string tag, Func<T, Structured> mapper, bool flow = false)
    => value.ToMap(k => k.Key, v => mapper(v.Value)).Render(tag, flow);

  internal static string IsLine(this string value)
    => value + Environment.NewLine;

  internal static string FlowList(this string[] value, string prefix = "")
    => value.Surround("[", "]", v => prefix + v, ",");

  internal static string FlowMap(this MapPair<string>[] list, string prefix = "")
    => list.OrderBy(kv => kv.Key).Surround("{", "}", v => v.Key + ":" + prefix + v.Value, ",");

  internal static string IsList(this string[] value, string prefix)
    => value.Joined(v => prefix + v, Environment.NewLine);

  internal static string IsList<T>(this T[] value, Func<T?, string> mapper)
    => value.Joined(mapper, Environment.NewLine);

  internal static string IsMap<T>(this MapPair<T>[] list, string prefix, Func<T, string> mapper)
    => list.OrderBy(kv => kv.Key).Joined(v => prefix + v.Key + ":" + mapper(v.Value), Environment.NewLine);
}
