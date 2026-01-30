using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

public static class MapHelpers
{
  public static MapPair<TPair> ToPair<TPair>(this TPair item, string key)
    => new(key, item);
  public static MapPair<TPair> ToPair<TPair>(this TPair item, [NotNull] Func<TPair, string> key)
    => new(key(item), item);
  public static MapPair<TPair> ToPair<TInput, TPair>(
    this TInput item,
    [NotNull] Func<TInput, string> key,
    [NotNull] Func<TInput, TPair> value
  ) => new(key(item), value(item));
  public static IEnumerable<MapPair<TMap>> ToPairs<TInput, TMap>(
    this IEnumerable<TInput>? items,
    Func<TInput, string> key,
    Func<TInput, TMap> value
  ) => items?.Select(item => item.ToPair(key, value)) ?? [];

  public static Map<TMap> ToMap<TMap>(this IEnumerable<TMap>? items, Func<TMap, string> key)
    => [.. items.ToPairs(key, i => i)];

  public static Map<TMap> ToMap<TInput, TMap>(
    this IEnumerable<TInput>? items,
    Func<TInput, string> key,
    Func<TInput, TMap> map
  ) => [.. items.ToPairs(key, map)];
}
