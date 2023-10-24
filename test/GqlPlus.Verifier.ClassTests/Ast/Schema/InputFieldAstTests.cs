namespace GqlPlus.Verifier.Ast.Schema;

public class InputFieldAstTests : BaseAliasedAstTests<InputFieldInput>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(InputFieldInput input)
      => _checks.HashCode(
        () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(InputFieldInput input)
    => _checks.String(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() },
      $"( !IF {input.Name} : {input.Type} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(InputFieldInput input)
    => _checks.Equality(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(InputFieldInput input)
    => _checks.InequalityWith(input,
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(InputFieldInput input, string def)
      => _checks.HashCode(
        () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(InputFieldInput input, string def)
    => _checks.String(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(InputFieldInput input, string def)
    => _checks.Equality(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenDefaults(InputFieldInput input, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      def1 == def2);

  protected override string InputString(InputFieldInput input)
    => $"( !IF {input.Name} : {input.Type} )";

  protected override string AliasesString(InputFieldInput input, params string[] aliases)
    => $"( !IF {input.Name} [ {aliases.Joined()} ] : {input.Type} )";

  private readonly BaseAliasedAstChecks<InputFieldInput, InputFieldAst> _checks
    = new(input => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)));

  internal override IBaseAliasedAstChecks<InputFieldInput> AliasedChecks => _checks;
}

public record struct InputFieldInput(string Name, string Type);
