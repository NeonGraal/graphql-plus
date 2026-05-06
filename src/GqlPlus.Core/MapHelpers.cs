using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

public static class MapHelpers
{
  public static KeyValuePair<TKey, TValue> ToKeyValue<TKey, TValue>(this TValue value, TKey key)
    => new(key, value);

  public static MapPair<TPair> ToPair<TPair>(this TPair item, string key)
    => new(key, item);
  public static MapPair<TPair> ToPair<TPair>(this TPair item, [NotNull] Func<TPair, string> key)
    => new(key(item), item);
  public static MapPair<TPair> ToPair<TInput, TPair>(
    this TInput item,
    [NotNull] Func<TInput, string> key,
    [NotNull] Func<TInput, TPair> value
  ) => new(key(item), value(item));

  public static MapPair<TPair> Select<TInput, TPair>(
    this MapPair<TInput> item,
    [NotNull] Func<TInput, TPair> value
  ) => new(item.Key, value(item.Value));

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
