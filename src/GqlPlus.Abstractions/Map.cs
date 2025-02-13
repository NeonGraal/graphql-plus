namespace GqlPlus;

public class Map<TMap>
  : Dictionary<string, TMap>
  , IMap<TMap>
  , IReadOnlyMap<TMap>
{
  public Map() { }
  public Map(IReadOnlyDictionary<string, TMap> dictionary)
    : base(dictionary.ToDictionary(k => k.Key, v => v.Value)) { }

  public TMap GetValueOrDefault(string key, TMap defaultValue)
    => TryGetValue(key, out TMap value) ? value : defaultValue;
  public bool TryAdd(string key, TMap value)
  {
    if (ContainsKey(key)) {
      return false;
    }

    Add(key, value);
    return true;
  }
}

public interface IMap<TMap>
  : IDictionary<string, TMap>
{
  TMap GetValueOrDefault(string key, TMap defaultValue);
  bool TryAdd(string key, TMap value);
}

public interface IReadOnlyMap<TMap>
  : IReadOnlyDictionary<string, TMap>
{
  TMap GetValueOrDefault(string key, TMap defaultValue);
}

public static class MapExtensions
{
  public static Map<TMap> ToMap<TMap>(this IEnumerable<TMap>? items, Func<TMap, string> key)
    => new(items?.ToDictionary(key) ?? []);

  public static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput>? items, Func<TInput, string> key, Func<TInput, TMap> map)
    => new(items?.ToDictionary(key, map) ?? []);
}
