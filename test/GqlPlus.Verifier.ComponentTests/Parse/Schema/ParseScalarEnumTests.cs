using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarEnumTests(
  Parser<AstScalar>.D parser
) : BaseScalarTests<ScalarEnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumType_ReturnsCorrectAst(ScalarEnumInput input, string enumType)
    => _checks.TrueExpected(
      input.Name + "{enum!" + enumType + "." + input.Member + "}",
      new AstScalar<ScalarMemberAst>(AstNulls.At, input.Name, ScalarKind.Enum, input.ScalarMember(enumType)));

  [Theory, RepeatData(Repeats)]
  public void WithMembers_ReturnsCorrectAst(ScalarEnumInput input, string member)
    => _checks.TrueExpected(
      input.Name + "{enum!" + input.Member + " " + member + "}",
      new AstScalar<ScalarMemberAst>(AstNulls.At, input.Name, ScalarKind.Enum, input.ScalarMembers(member)));

  [Theory, RepeatData(Repeats)]
  public void WithMembersFirstBad_ReturnsFalse(ScalarEnumInput input)
    => _checks.False(input.Name + "{enum " + input.Member + ".}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersSecondBad_ReturnsFalse(ScalarEnumInput input, string member)
    => _checks.False(input.Name + "{enum " + input.Member + "!" + member + ".}");

  internal override IBaseScalarChecks<ScalarEnumInput> ScalarChecks => _checks;

  private readonly ParseScalarEnumChecks _checks = new(parser);
}

internal sealed class ParseScalarEnumChecks(
  Parser<AstScalar>.D parser
) : BaseScalarChecks<ScalarEnumInput, AstScalar>(parser, ScalarKind.Enum)
{
  protected internal override AstScalar<ScalarMemberAst> AliasedFactory(ScalarEnumInput input)
    => new(AstNulls.At, input.Name, ScalarKind.Enum, input.ScalarMembers());

  protected internal override string AliasesString(ScalarEnumInput input, string aliases)
    => input.Name + aliases + "{enum !" + input.Member + "}";
  protected internal override string KindString(ScalarEnumInput input, string kind, string extends)
    => input.Name + "{" + kind + extends + "!" + input.Member + "}";
}

public record struct ScalarEnumInput(string Name, string Member)
{
  internal readonly ScalarMemberAst[] ScalarMember(string enumType)
      => [new(AstNulls.At, true, Member) { EnumType = enumType }];

  internal readonly ScalarMemberAst[] ScalarMembers(params string[] members)
      => [.. members.Select(r => new ScalarMemberAst(AstNulls.At, false, r)).Prepend(new(AstNulls.At, true, Member))];
}
