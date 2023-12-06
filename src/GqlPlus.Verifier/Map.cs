namespace GqlPlus.Verifier;

internal class Map<T> : Dictionary<string, T>, IMap<T>
{
  public Map(IDictionary<string, T> dictionary)
    : base(dictionary) { }
}

public interface IMap<T> : IDictionary<string, T>;

internal static class MapExtensions
{
  internal static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput> items, Func<TInput, string> key, Func<TInput, TMap> map)
    => new(items.ToDictionary(key, map));
}
