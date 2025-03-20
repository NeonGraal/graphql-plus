using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstDomainItem(
  TokenAt At,
  string Description,
  bool Excludes
) : AstAbbreviated(At)
  , IEquatable<AstDomainItem>
  , IGqlpDomainItem
{
  public virtual bool Equals(AstDomainItem? other)
  => base.Equals(other)
      && Excludes.NullEqual(other.Excludes);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Excludes);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Excludes ? "!" : "");
}
