namespace GqlPlus.Verifier.Ast;

internal record class AstBase
{
  public sealed override string ToString()
    => GetType().Name.Replace("Ast", "(")
      + string.Join(" ", GetFields().Where(s => s is { Length: > 0 }))
      + ")";

  internal virtual IEnumerable<string?> GetFields()
    => Array.Empty<string?>();
}

