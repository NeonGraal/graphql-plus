namespace GqlPlus;

public interface IMap<TMap>
  : IDictionary<string, TMap>
{
  bool TryAdd(string key, TMap value);
}
