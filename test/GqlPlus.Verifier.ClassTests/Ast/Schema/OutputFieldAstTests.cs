namespace GqlPlus.Verifier.Ast.Schema;

public class OutputFieldAstTests : BaseAliasedAstTests<OutputFieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameter(OutputFieldInput input, string[] parameters)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameters(OutputFieldInput input, string[] parameters)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      $"( !OF {input.Name} ( {parameters.Joined("!P ")} ) : {input.Type} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameter(OutputFieldInput input, string[] parameters)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenParameters(OutputFieldInput input, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      parameters1.SequenceEqual(parameters2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(OutputFieldInput input)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(OutputFieldInput input)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() },
      $"( !OF {input.Name} : {input.Type} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(OutputFieldInput input)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(OutputFieldInput input)
    => _checks.InequalityWith(input,
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(OutputFieldInput input, string enumValue)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(OutputFieldInput input, string enumValue)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue },
      $"( !OF {input.Name} = {input.Type}.{enumValue} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(OutputFieldInput input, string enumValue)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(OutputFieldInput input, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumValue => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { EnumValue = enumValue },
      enumValue1 == enumValue2);

  protected override string InputString(OutputFieldInput input)
    => $"( !OF {input.Name} : {input.Type} )";

  protected override string AliasesString(OutputFieldInput input, params string[] aliases)
    => $"( !OF {input.Name} [ {aliases.Joined()} ] : {input.Type} )";

  private readonly BaseAliasedAstChecks<OutputFieldInput, OutputFieldAst> _checks
    = new(input => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)));

  internal override IBaseAliasedAstChecks<OutputFieldInput> AliasedChecks => _checks;
}

public record struct OutputFieldInput(string Name, string Type);
