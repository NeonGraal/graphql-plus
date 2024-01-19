namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstEnumTests
  : AstScalarTests<ScalarDeclEnumAst, ScalarMemberEnumAst, string>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnum(string name, string input)
      => Checks.HashCode(() => NewScalar(name, input, []));

  [Theory, RepeatData(Repeats)]
  public void String_WithEnum(string name, string input)
    => Checks.String(
      () => NewScalar(name, input, []),
      $"( !S {name} Enum {input} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnum(string name, string input)
    => Checks.Equality(() => NewScalar(name, input, []));

  protected override ScalarMemberEnumAst NewScalarMember(string? lower, string? upper, bool? rightNull)
    => rightNull switch {
      false => new(AstNulls.At, false, null, upper),
      true => new(AstNulls.At, false, lower, null),
      _ => new(AstNulls.At, false, lower, upper),
    };

  protected override ScalarDeclEnumAst NewScalar(string name, string input, ScalarMemberEnumAst[] list)
    => new(AstNulls.At, name, input, list);
}
