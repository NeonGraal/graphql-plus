using GqlPlus.Ast.Schema;

namespace GqlPlus;

internal class Map<T> : Dictionary<string, T>, IMap<T>, IReadOnlyMap<T>
{
  public Map() { }
  public Map(IReadOnlyDictionary<string, T> dictionary) : base(dictionary) { }
}

[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix")]
public interface IMap<T> : IDictionary<string, T>;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix")]
public interface IReadOnlyMap<T> : IReadOnlyDictionary<string, T>;

internal static class MapExtensions
{
  internal static Map<TMap> ToMap<TMap>(this IEnumerable<TMap>? items, Func<TMap, string> key)
    => new(items?.ToDictionary(key) ?? []);

  internal static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput>? items, Func<TInput, string> key, Func<TInput, TMap> map)
    => new(items?.ToDictionary(key, map) ?? []);

  internal static IEnumerable<IGrouping<string, TAliased>> AliasedGroup<TAliased>(this TAliased[] items)
    where TAliased : AstAliased
  {
    var names = items.Select(d => d.Name).Distinct().ToHashSet();

    return items.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .GroupBy(p => p.Id, p => p.Item)
      .Union(items.GroupBy(t => t.Name));
  }

  internal static Map<TResult> AliasedMap<TAliased, TResult>(this TAliased[] items, Func<IEnumerable<TAliased>, TResult> element)
    where TAliased : AstAliased
    => AliasedGroup(items)
      .ToMap(g => g.Key, g => element(g));
}
