namespace GqlPlus.Ast;

public static class AstHelpers
{
  public static IEnumerable<string?> Bracket(this IAstAbbreviated? item, string before, string after)
    => item?.GetFields().Prepend(before).Append(after) ?? [];

  public static string Prefixed(this IAstAbbreviated? ast, string prefix)
    => ast is null ? "" : $"{prefix}{ast}";
}
