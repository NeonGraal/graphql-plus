using GqlPlus.Abstractions.Schema;

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

  private readonly AstObjectFieldChecks<OutputFieldAst> _checks = new(CreateOutput, CloneOutput);

  private static OutputFieldAst CloneOutput(OutputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static OutputFieldAst CreateOutput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}

public class OutputFieldAstTypeTests
    : ObjFieldTypeTests<FieldInput>
{
  private readonly OutputFieldAstTypeChecks _checks = new(CreateInput, CloneInput);

  private static OutputFieldAst CloneInput(OutputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static OutputFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IObjFieldTypeChecks<FieldInput> FieldChecks => _checks;

  protected override string InputString(FieldInput input)
    => $"( !OF {input.Name} : {input.Type} )";
}


internal sealed class OutputFieldAstTypeChecks(
  ObjFieldTypeChecks<FieldInput, OutputFieldAst>.TypeBy createType,
  BaseAstChecks<OutputFieldAst>.CloneBy<FieldInput> cloneInput
) : ObjFieldTypeChecks<FieldInput, OutputFieldAst>(createType, cloneInput)
{
  protected override OutputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override OutputFieldAst WithModifiers(OutputFieldAst objType)
    => objType with { Modifiers = TestMods() };
}
