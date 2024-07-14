using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputFieldAstTests
  : AstObjectFieldTests<IGqlpOutputBase>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParam(FieldInput input, string[] parameters)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type)) { Params = parameters.Params() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParams(FieldInput input, string[] parameters)
    => _checks.Text(
      () => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type)) { Params = parameters.Params() },
      $"( !OF {input.Name} ( {parameters.Joined(s => "!Pa " + s)} ) : {input.Type} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParam(FieldInput input, string[] parameters)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type)) { Params = parameters.Params() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParams(FieldInput input, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type)) { Params = parameters.Params() },
      parameters1.SequenceEqual(parameters2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithEnumValue(FieldInput input, string enumMember)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type) { EnumMember = enumMember }));

  [Theory, RepeatData(Repeats)]
  public void String_WithEnumValue(FieldInput input, string enumMember)
    => _checks.Text(
      () => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type) { EnumMember = enumMember }),
      $"( !OF {input.Name} = {input.Type}.{enumMember} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithEnumValue(FieldInput input, string enumMember)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type) { EnumMember = enumMember }));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenEnumValues(FieldInput input, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumMember => new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type) { EnumMember = enumMember }),
      enumValue1 == enumValue2);

  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !OF {input.Name}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<OutputFieldAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst> _checks = new(
          (input, objBase) => new(AstNulls.At, input.Name, objBase),
      input => new(AstNulls.At, input.Type),
      arguments => arguments.OutputArgs());

  internal override IAstObjectFieldChecks<IGqlpOutputBase> FieldChecks => _checks;
}
