using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarMemberAst(TokenAt At, bool Excludes, string Member)
  : AstScalarMember(At, Excludes), IEquatable<ScalarMemberAst>
{
  public string? EnumType { get; set; }

  internal override string Abbr => "SM";

  public bool Equals(ScalarMemberAst? other)
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
