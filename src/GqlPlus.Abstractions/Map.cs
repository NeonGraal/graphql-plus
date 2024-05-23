namespace GqlPlus;

public class Map<T> : Dictionary<string, T>, IMap<T>, IReadOnlyMap<T>
{
  public Map() { }
  public Map(IReadOnlyDictionary<string, T> dictionary) : base(dictionary) { }
}

public interface IMap<T> : IDictionary<string, T>;

public interface IReadOnlyMap<T> : IReadOnlyDictionary<string, T>;

public static class MapExtensions
{
  public static Map<TMap> ToMap<TMap>(this IEnumerable<(string, TMap)>? items)
    => new(items?.ToDictionary() ?? []);

  public static Map<TMap> ToMap<TMap>(this IEnumerable<TMap>? items, Func<TMap, string> key)
    => new(items?.ToDictionary(key) ?? []);

  public static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput>? items, Func<TInput, string> key, Func<TInput, TMap> map)
    => new(items?.ToDictionary(key, map) ?? []);

}
