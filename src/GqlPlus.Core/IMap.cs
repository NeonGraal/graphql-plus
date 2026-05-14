namespace GqlPlus;

public interface IMap<TMap>
  : IDictionary<string, TMap>
{
  bool TryAdd(string key, TMap value);
  TMap? GetValueOr(string key);
}

public interface IReadOnlyMap<TMap>
  : IReadOnlyDictionary<string, TMap>
{
  TMap? GetValueOr(string key);
}
