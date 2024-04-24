namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class OutputFieldAstTests : AstFieldTests<OutputFieldAst, OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameter(FieldInput input, string[] parameters)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameters(FieldInput input, string[] parameters)
    => _checks.Text(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      $"( !OF {input.Name} ( {parameters.Joined(s => "!Pa " + s)} ) : {input.Type} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameter(FieldInput input, string[] parameters)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParameters(FieldInput input, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      parameters1.SequenceEqual(parameters2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(FieldInput input, string enumValue)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type) { EnumValue = enumValue }));

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(FieldInput input, string enumValue)
    => _checks.Text(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type) { EnumValue = enumValue }),
      $"( !OF {input.Name} = {input.Type}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(FieldInput input, string enumValue)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type) { EnumValue = enumValue }));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(FieldInput input, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumValue => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type) { EnumValue = enumValue }),
      enumValue1 == enumValue2);

  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !OF {input.Name}{aliases} : {input.Type} )";

  private readonly AstFieldChecks<OutputFieldAst, OutputReferenceAst> _checks = new(
          (input, reference) => new(AstNulls.At, input.Name, reference),
      input => new(AstNulls.At, input.Type),
      arguments => arguments.OutputReferences());

  internal override IAstFieldChecks<OutputFieldAst, OutputReferenceAst> FieldChecks => _checks;
}
