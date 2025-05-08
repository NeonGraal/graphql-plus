using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstNamed(
  TokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Description)
  , IGqlpNamed
{
  public string Name { get; set; } = Name;

  public virtual bool Equals(AstNamed? other)
    => other is IGqlpNamed named && Equals(named);
  public bool Equals(IGqlpNamed? other)
    => base.Equals(other)
    && string.Equals(Name, other.Name, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Name);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Name);
}
