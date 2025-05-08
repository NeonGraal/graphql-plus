using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputArgAstTests
  : AstObjectArgTests<IGqlpOutputArg>
{
  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string name, string enumLabel)
      => _checks.HashCode(
        () => new OutputArgAst(AstNulls.At, name) { EnumLabel = enumLabel });

  [Theory, RepeatData]
  public void String_WithEnumValue(string name, string enumLabel)
    => _checks.Text(
      () => new OutputArgAst(AstNulls.At, name) { EnumLabel = enumLabel },
      $"( {name}.{enumLabel} )");

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string name, string enumLabel)
    => _checks.Equality(
      () => new OutputArgAst(AstNulls.At, name) { EnumLabel = enumLabel });

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumLabel => new OutputArgAst(AstNulls.At, name) { EnumLabel = enumLabel },
      enumValue1 == enumValue2);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgChecks<IGqlpOutputArg, OutputArgAst> _checks
    = new(name => new OutputArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpOutputArg> ObjArgChecks => _checks;
}
