using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainRegexAst(
  TokenAt At,
  string Description,
  bool Excludes,
  string Pattern
) : AstDomainItem(At, Description, Excludes)
  , IGqlpDomainRegex
{
  internal override string Abbr => "DX";

  public bool Equals(DomainRegexAst? other)
    => other is IGqlpDomainRegex regex && Equals(regex);
  public bool Equals(IGqlpDomainRegex? other)
    => base.Equals(other)
      && Pattern == other.Pattern
      && Excludes == other.Excludes;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Pattern, Excludes);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Pattern.Quoted("/").Prefixed(Excludes ? "!" : ""));
}
