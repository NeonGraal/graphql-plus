namespace GqlPlus;

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
