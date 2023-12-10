namespace GqlPlus.Verifier.Ast.Schema;

public class OutputFieldAstTests : AstFieldTests<OutputFieldAst, OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameter(FieldInput input, string[] parameters)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameters(FieldInput input, string[] parameters)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      $"( !OF {input.Name} ( {parameters.Joined("!P ")} ) : {input.Type} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameter(FieldInput input, string[] parameters)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenParameters(FieldInput input, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      parameters1.SequenceEqual(parameters2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(FieldInput input, string enumValue)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(FieldInput input, string enumValue)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue },
      $"( !OF {input.Name} = {input.Type}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(FieldInput input, string enumValue)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(FieldInput input, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumValue => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue },
      enumValue1 == enumValue2);

  protected override string InputString(FieldInput input)
    => $"( !OF {input.Name} : {input.Type} )";

  protected override string AliasesString(FieldInput input, params string[] aliases)
    => $"( !OF {input.Name} [ {aliases.Joined()} ] : {input.Type} )";

  private readonly AstFieldChecks<OutputFieldAst, OutputReferenceAst> _checks
    = new(input => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)));

  internal override IAstFieldChecks<OutputFieldAst, OutputReferenceAst> FieldChecks => _checks;
}
