using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public sealed record class DomainRegexAst(TokenAt At, bool Excludes, string Regex)
  : AstDomainItem(At, Excludes), IEquatable<DomainRegexAst>
{
  internal override string Abbr => "DX";

  public bool Equals(DomainRegexAst? other)
    => base.Equals(other)
      && Regex == other.Regex
      && Excludes == other.Excludes;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Regex, Excludes);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Regex.Quoted("/").Prefixed(Excludes ? "!" : ""));
}
