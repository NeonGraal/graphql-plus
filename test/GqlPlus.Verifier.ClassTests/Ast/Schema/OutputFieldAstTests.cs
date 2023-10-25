namespace GqlPlus.Verifier.Ast.Schema;

public class OutputFieldAstTests : BaseAliasedAstTests<OutputFieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameter(OutputFieldInput input, string param)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameter = new ParameterAst(AstNulls.At, param) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameter(OutputFieldInput input, string param)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameter = new ParameterAst(AstNulls.At, param) },
      $"( !OF {input.Name} ( !P {param} ) : {input.Type} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameter(OutputFieldInput input, string param)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameter = new ParameterAst(AstNulls.At, param) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenParameters(OutputFieldInput input, string param1, string param2)
    => _checks.InequalityBetween(param1, param2,
      param => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Parameter = new ParameterAst(AstNulls.At, param) },
      param1 == param2);

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
  public void HashCode_WithLabel(OutputFieldInput input, string label)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Label = label });

  [Theory, RepeatData(Repeats)]
  public void String_WithLabel(OutputFieldInput input, string label)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Label = label },
      $"( !OF {input.Name} = {input.Type}.{label} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabel(OutputFieldInput input, string label)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Label = label });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenLabels(OutputFieldInput input, string label1, string label2)
    => _checks.InequalityBetween(label1, label2,
      label => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Label = label },
      label1 == label2);

  protected override string InputString(OutputFieldInput input)
    => $"( !OF {input.Name} : {input.Type} )";

  protected override string AliasesString(OutputFieldInput input, params string[] aliases)
    => $"( !OF {input.Name} [ {aliases.Joined()} ] : {input.Type} )";

  private readonly BaseAliasedAstChecks<OutputFieldInput, OutputFieldAst> _checks
    = new(input => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)));

  internal override IBaseAliasedAstChecks<OutputFieldInput> AliasedChecks => _checks;
}

public record struct OutputFieldInput(string Name, string Type);
