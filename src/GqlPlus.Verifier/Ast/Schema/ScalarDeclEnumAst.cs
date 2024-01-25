using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarDeclEnumAst(
  TokenAt At,
  string Name,
  string Description
) : AstScalar<ScalarMemberEnumAst>(At, Name, Description, ScalarKind.Enum), IEquatable<ScalarDeclEnumAst>
{
  public string? EnumType { get; set; }

  public ScalarDeclEnumAst(TokenAt at, string name, string enumType, ScalarMemberEnumAst[] members)
    : this(at, name, "")
    => (EnumType, Members) = (enumType, members);

  public bool Equals(ScalarDeclEnumAst? other)
    => base.Equals(other)
      && EnumType.NullEqual(other.EnumType);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumType);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(EnumType);
}
