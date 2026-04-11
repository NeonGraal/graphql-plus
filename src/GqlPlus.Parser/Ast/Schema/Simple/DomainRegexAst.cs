using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainRegexAst(
  ITokenAt At,
  string Description,
  bool Excludes,
  string Pattern
) : AstDomainItem(At, Description, Excludes)
  , IAstDomainRegex
{
  internal override string Abbr => "DX";

  public bool Equals(DomainRegexAst? other)
    => other is IAstDomainRegex regex && Equals(regex);
  public bool Equals(IAstDomainRegex? other)
    => base.Equals(other)
      && Pattern == other.Pattern
      && Excludes == other.Excludes;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Pattern, Excludes);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append((Excludes ? "!" : "") + Pattern.Quoted('/'));
}
