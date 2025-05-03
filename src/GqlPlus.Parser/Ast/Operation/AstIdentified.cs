using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal abstract record class AstIdentified(
  ITokenAt At,
  string Identifier
) : AstAbbreviated(At)
  , IEquatable<AstIdentified>
  , IGqlpIdentified
{
  public virtual bool Equals(AstIdentified? other)
    => base.Equals(other)
    && string.Equals(Identifier, other.Identifier, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Identifier);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Identifier);
}
