using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Ast.Schema;

public static class SchemaAbstractionHelpers
{
  public static IEnumerable<IGrouping<string, TAliased>> AliasedGroup<TAliased>(this TAliased[] items)
    where TAliased : IAstAliased
  {
    HashSet<string> names = [.. items.Select(d => d.Name).Distinct()];

    return items.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .GroupBy(p => p.Id, p => p.Item)
      .Union(items.GroupBy(t => t.Name));
  }

  public static IMap<TResult> AliasedMap<TAliased, TResult>(this TAliased[] items, Func<IEnumerable<TAliased>, TResult> element)
    where TAliased : IAstAliased
    => AliasedGroup(items)
      .ToMap(g => g.Key, g => element(g));

  public static IEnumerable<string> NameAndAliases<T>([NotNull] this T aliased)
    where T : IAstAliased
    => aliased.Aliases.Prepend(aliased.Name).Distinct();
}
