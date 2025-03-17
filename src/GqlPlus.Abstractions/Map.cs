namespace GqlPlus;

public class Map<TMap>
  : Dictionary<string, TMap>
  , IMap<TMap>
  , IReadOnlyMap<TMap>
{
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

  public void Add(MapPair<TMap> item)
    => Add(item.Key, item.Value);
}

public record struct MapPair<TMap>(string Key, TMap Value)
{
  public static implicit operator KeyValuePair<string, TMap>(MapPair<TMap> pair)
    => new(pair.Key, pair.Value);
  public static implicit operator MapPair<TMap>(KeyValuePair<string, TMap> pair)
    => new(pair.Key, pair.Value);
}
