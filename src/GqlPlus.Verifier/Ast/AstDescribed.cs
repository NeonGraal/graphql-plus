namespace GqlPlus.Verifier.Ast;

internal abstract record class AstDescribed(ParseAt At, string Name, string Description)
  : AstNamed(At, Name), IEquatable<AstDescribed>
{
  public virtual bool Equals(AstDescribed? other)
    => base.Equals(other)
    && Description.Equals(other.Description);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Description);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Description.Quoted("\""));
}
