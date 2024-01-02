namespace GqlPlus.Verifier.Ast.Schema;

public class InputFieldAstTests : AstFieldTests<InputFieldAst, InputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(FieldInput input, string def)
      => _checks.HashCode(
        () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(FieldInput input, string def)
    => _checks.String(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(FieldInput input, string def)
    => _checks.Equality(
      () => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenDefaults(FieldInput input, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputFieldAst(AstNulls.At, input.Name, new(AstNulls.At, input.Type)) { Default = new FieldKeyAst(AstNulls.At, def) },
      def1 == def2);

  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !IF {input.Name}{aliases} : {input.Type} )";

  private readonly AstFieldChecks<InputFieldAst, InputReferenceAst> _checks = new(
      (input, reference) => new(AstNulls.At, input.Name, reference),
      input => new(AstNulls.At, input.Type),
      arguments => arguments.InputReferences());

  internal override IAstFieldChecks<InputFieldAst, InputReferenceAst> FieldChecks => _checks;
}
