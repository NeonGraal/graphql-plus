namespace GqlPlus.Abstractions;

public static class AbstractionHelpers
{
  public static IEnumerable<string?> Bracket(this IGqlpAbbreviated? item, string before, string after)
    => item?.GetFields().Prepend(before).Append(after) ?? [];

  public static string Prefixed(this IGqlpAbbreviated? ast, string prefix)
    => ast is null ? "" : $"{prefix}{ast}";
}
