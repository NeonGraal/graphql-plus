using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal abstract record class AstIdentified(
  ITokenAt At,
  string Identifier
) : AstAbbreviated(At)
  , IGqlpIdentified
{

  public virtual bool Equals(AstIdentified? other)
    => other is IGqlpIdentified identified && Equals(identified);
  public bool Equals(IGqlpIdentified? other)
    => base.Equals(other)
    && string.Equals(Identifier, other.Identifier, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Identifier);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Identifier);
}
