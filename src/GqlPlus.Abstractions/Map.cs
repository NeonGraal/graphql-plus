namespace GqlPlus;

public class Map<TMap>
  : Dictionary<string, TMap>
  , IMap<TMap>
  , IReadOnlyMap<TMap>
{
  public Map() { }
  public Map(IReadOnlyDictionary<string, TMap> dictionary)
    : base(dictionary) { }
}

public interface IMap<TMap>
  : IDictionary<string, TMap>;

public interface IReadOnlyMap<TMap>
  : IReadOnlyDictionary<string, TMap>;

public static class MapExtensions
{
  public static Map<TMap> ToMap<TMap>(this IEnumerable<TMap>? items, Func<TMap, string> key)
    => new(items?.ToDictionary(key) ?? []);

  public static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput>? items, Func<TInput, string> key, Func<TInput, TMap> map)
    => new(items?.ToDictionary(key, map) ?? []);
}
