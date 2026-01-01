using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstDomainItem(
  ITokenAt At,
  string Description,
  bool Excludes
) : AstAbbreviated(At)
  , IGqlpDomainItem
{
  public bool Equals(IGqlpDomainItem? other)
  => Equals(other as IGqlpDescribed)
      && Excludes.NullEqual(other.Excludes);
  public bool Equals(IGqlpDescribed? other)
  => base.Equals(other)
    && Description.NullEqual(other.Description);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Excludes);
}
