using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstScalarMember(TokenAt At, bool Excludes)
  : AstAbbreviated(At), IEquatable<AstScalarMember>
{
  public virtual bool Equals(AstScalarMember? other)
  => base.Equals(other)
      && Excludes.NullEqual(other.Excludes);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Excludes);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Excludes ? "!" : "");
}
