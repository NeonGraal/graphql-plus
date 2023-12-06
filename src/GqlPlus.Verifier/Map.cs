using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

internal class Map<T>(IDictionary<string, T> dictionary)
  : Dictionary<string, T>(dictionary), IMap<T>
{ }

public interface IMap<T> : IDictionary<string, T>;

internal static class MapExtensions
{
  internal static Map<TMap> ToMap<TInput, TMap>(this IEnumerable<TInput> items, Func<TInput, string> key, Func<TInput, TMap> map)
    => new(items.ToDictionary(key, map));

  internal static Map<TAliased[]> AliasedMap<TAliased>(this TAliased[] items)
    where TAliased : AstAliased
  {
    var names = items.Select(d => d.Name).Distinct().ToHashSet();

    return items.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .GroupBy(p => p.Id, p => p.Item)
      .Union(items.GroupBy(t => t.Name))
      .ToMap(g => g.Key, g => g.ToArray());
  }
}
