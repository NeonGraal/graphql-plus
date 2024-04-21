using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstDomainItem(TokenAt At, bool Excludes)
  : AstAbbreviated(At), IEquatable<AstDomainItem>, IAstDomainItem
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

[SuppressMessage("Design", "CA1040:Avoid empty interfaces")]
public interface IAstDomainItem { }
