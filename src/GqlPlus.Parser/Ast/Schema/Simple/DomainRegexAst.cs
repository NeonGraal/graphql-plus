using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainRegexAst(
  TokenAt At,
  bool Excludes,
  string Pattern
) : AstDomainItem(At, Excludes)
  , IEquatable<DomainRegexAst>
  , IGqlpDomainRegex
{
  internal override string Abbr => "DX";

  public bool Equals(DomainRegexAst? other)
    => base.Equals(other)
      && Pattern == other.Pattern
      && Excludes == other.Excludes;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Pattern, Excludes);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Pattern.Quoted("/").Prefixed(Excludes ? "!" : ""));
}
