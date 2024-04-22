using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

public sealed record class DomainMemberAst(TokenAt At, bool Excludes, string Member)
  : AstDomainItem(At, Excludes), IEquatable<DomainMemberAst>
{
  public string? EnumType { get; set; }

  internal override string Abbr => "SM";

  public bool Equals(DomainMemberAst? other)
    => base.Equals(other)
      && Member.NullEqual(other.Member)
      && EnumType.NullEqual(other.EnumType);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Member, EnumType);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Excludes ? "!" : "")
      .Append(EnumType)
      .Append(Member);
}
