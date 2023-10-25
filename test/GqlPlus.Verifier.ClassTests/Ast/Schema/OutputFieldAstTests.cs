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
  public void HashCode_WithDefault(OutputFieldInput input, string def)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(OutputFieldInput input, string def)
    => _checks.String(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      $"( !OF {input.Name} : {input.Type} =( !k '{def}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(OutputFieldInput input, string def)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenDefaults(OutputFieldInput input, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      def1 == def2);

  protected override string InputString(OutputFieldInput input)
    => $"( !OF {input.Name} : {input.Type} )";

  protected override string AliasesString(OutputFieldInput input, params string[] aliases)
    => $"( !OF {input.Name} [ {aliases.Joined()} ] : {input.Type} )";

  private readonly BaseAliasedAstChecks<OutputFieldInput, OutputFieldAst> _checks
    = new(input => new OutputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)));

  internal override IBaseAliasedAstChecks<OutputFieldInput> AliasedChecks => _checks;
}

public record struct OutputFieldInput(string Name, string Type);
