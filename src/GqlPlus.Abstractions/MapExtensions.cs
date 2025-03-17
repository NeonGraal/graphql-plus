namespace GqlPlus;

public static class MapExtensions
{
  public static IEnumerable<MapPair<TMap>> ToPairs<TInput, TMap>(this IEnumerable<TInput>? items, Func<TInput, string> key, Func<TInput, TMap> value)
    => items?.Select(item => new MapPair<TMap>(key(item), value(item))) ?? [];

  public static Map<TMap> ToMap<TMap>(this IEnumerable<TMap>? items, Func<TMap, string> key)
    => [.. items.ToPairs(key, i => i)];

  public static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput>? items, Func<TInput, string> key, Func<TInput, TMap> map)
    => [.. items.ToPairs(key, map)];
}
