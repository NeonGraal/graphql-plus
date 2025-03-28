using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputBaseAstTests
  : AstObjectBaseTests<IGqlpOutputBase>
{
  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string name, string enumLabel)
      => _checks.HashCode(
        () => new OutputBaseAst(AstNulls.At, name) { EnumLabel = enumLabel });

  [Theory, RepeatData]
  public void String_WithEnumValue(string name, string enumLabel)
    => _checks.Text(
      () => new OutputBaseAst(AstNulls.At, name) { EnumLabel = enumLabel },
      $"( {name}.{enumLabel} )");

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string name, string enumLabel)
    => _checks.Equality(
      () => new OutputBaseAst(AstNulls.At, name) { EnumLabel = enumLabel });

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumLabel => new OutputBaseAst(AstNulls.At, name) { EnumLabel = enumLabel },
      enumValue1 == enumValue2);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst> _checks
    = new(name => new OutputBaseAst(AstNulls.At, name), arguments => arguments.OutputArgs());

  internal override IAstObjBaseChecks<IGqlpOutputBase> ObjBaseChecks => _checks;
}
