namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstDomainItem(
  ITokenAt At,
  string Description,
  bool Excludes
) : AstAbbreviated(At)
  , IAstDomainItem
{
  public bool Equals(IAstDomainItem? other)
  => Equals(other as IAstDescribed)
      && Excludes.NullEqual(other.Excludes);
  public bool Equals(IAstDescribed? other)
  => base.Equals(other)
    && Description.NullEqual(other.Description);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Excludes);
}
