namespace GqlPlus.Ast.Schema.Objects;

public class OutputFieldAstTests
  : AstObjectFieldTests
{
  [Theory, RepeatData]
  public void HashCode_WithParam(FieldInput input, string[] parameters)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { Params = parameters.Params() });

  [Theory, RepeatData]
  public void String_WithParams(FieldInput input, string[] parameters)
    => _checks.Text(
      () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { Params = parameters.Params() },
      $"( !OF {input.Name} ( {parameters.Joined(s => "!Pa " + s)} ) : {input.Type} )");

  [Theory, RepeatData]
  public void Equality_WithParam(FieldInput input, string[] parameters)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { Params = parameters.Params() });

  [Theory, RepeatData]
  public void Inequality_BetweenParams(FieldInput input, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { Params = parameters.Params() },
      parameters1.SequenceEqual(parameters2));

  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<OutputFieldAst> _checks = new(
          (input, objBase) => new(AstNulls.At, input.Name, objBase));

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}
