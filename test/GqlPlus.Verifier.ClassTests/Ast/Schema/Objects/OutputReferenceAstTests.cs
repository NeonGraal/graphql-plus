namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class OutputReferenceAstTests : AstReferenceTests<OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(string name, string enumValue)
      => _checks.HashCode(
        () => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(string name, string enumValue)
    => _checks.Text(
      () => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue },
      $"( {name}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(string name, string enumValue)
    => _checks.Equality(
      () => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumValue => new OutputReferenceAst(AstNulls.At, name) { EnumValue = enumValue },
      enumValue1 == enumValue2);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstReferenceChecks<OutputReferenceAst> _checks
    = new(name => new OutputReferenceAst(AstNulls.At, name), arguments => arguments.OutputReferences());

  internal override IAstReferenceChecks<OutputReferenceAst> ReferenceChecks => _checks;
}
