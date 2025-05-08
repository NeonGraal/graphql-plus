using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstDomainItem(
  ITokenAt At,
  string Description,
  bool Excludes
) : AstDescribed(At, Description)
  , IGqlpDomainItem
{
  public virtual bool Equals(IGqlpDomainItem? other)
  => base.Equals(other)
      && Excludes.NullEqual(other.Excludes);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Excludes);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Excludes ? "!" : "");
}
