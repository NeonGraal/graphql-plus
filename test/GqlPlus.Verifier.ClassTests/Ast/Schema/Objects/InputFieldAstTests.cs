namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class InputFieldAstTests : AstObjectFieldTests<InputFieldAst, InputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(FieldInput input, string def)
      => _checks.HashCode(
        () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(FieldInput input, string def)
    => _checks.Text(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(FieldInput input, string def)
    => _checks.Equality(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenDefaults(FieldInput input, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      def1 == def2);

  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !IF {input.Name}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<InputFieldAst, InputBaseAst> _checks = new(
      (input, objBase) => new(AstNulls.At, input.Name, objBase),
      input => new(AstNulls.At, input.Type),
      arguments => arguments.InputBases());

  internal override IAstObjectFieldChecks<InputFieldAst, InputBaseAst> FieldChecks => _checks;
}
