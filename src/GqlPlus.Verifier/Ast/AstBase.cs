namespace GqlPlus.Verifier.Ast;

internal record class AstBase
{
  public override string ToString()
    => GetType().Name.Replace("Ast", "(")
      + string.Join(" ", GetFields().Where(s => s is not null))
      + ")";

  internal virtual IEnumerable<string?> GetFields()
    => Array.Empty<string?>();
}
