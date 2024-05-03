namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class OutputBaseAstTests
  : AstObjBaseTests<OutputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(string name, string enumValue)
      => _checks.HashCode(
        () => new OutputBaseAst(AstNulls.At, name) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string name, string enumValue)
    => _checks.Text(
      () => new OutputBaseAst(AstNulls.At, name) { EnumValue = enumValue },
      $"( {name}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string name, string enumValue)
    => _checks.Equality(
      () => new OutputBaseAst(AstNulls.At, name) { EnumValue = enumValue });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumValue => new OutputBaseAst(AstNulls.At, name) { EnumValue = enumValue },
      enumValue1 == enumValue2);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<OutputBaseAst> _checks
    = new(name => new OutputBaseAst(AstNulls.At, name), arguments => arguments.OutputBases());

  internal override IAstObjBaseChecks<OutputBaseAst> ObjBaseChecks => _checks;
}
