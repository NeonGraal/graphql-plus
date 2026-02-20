using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public partial class OutputFieldAstTests
{
  [Theory, RepeatData]
  public void HashCode_WithParam(FieldInput input, string parameter)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, string.Empty)) { Parameter = parameter.Parameter() });

  [Theory, RepeatData]
  public void Text_WithParams(FieldInput input, string parameter)
    => _checks.Text(
      () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, string.Empty)) { Parameter = parameter.Parameter() },
      $"( !OF {input.Name} ( !Pa {parameter} ) : {input.Type} )");

  [Theory, RepeatData]
  public void Equality_WithParam(FieldInput input, string parameter)
    => _checks.Equality(
      () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, string.Empty)) { Parameter = parameter.Parameter() });

  [Theory, RepeatData]
  public void Inequality_BetweenParams(FieldInput input, string parameter1, string parameter2)
    => _checks.InequalityBetween(parameter1, parameter2,
      parameter => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, string.Empty)) { Parameter = parameter.Parameter() },
      parameter1 == parameter2);

  private readonly OutputFieldAstChecks _checks = new();

  [CheckTests, CheckTests(typeof(IAstNamedChecks<FieldInput>))]
  private IAstAliasedChecks<FieldInput> FieldChecks => _checks;

  [CheckTests(Inherited = true)]
  internal IObjFieldTypeChecks<FieldInput> FieldTypeChecks { get; }
    = new OutputFieldAstTypeChecks();

  [CheckTests]
  internal IModifiersChecks<FieldInput> ModifiersChecks { get; }
    = new ObjFieldModifiersChecks<FieldInput, OutputFieldAst>(
      CreateOutput,
      ast => ast with { Modifiers = TestMods() });

  [CheckTests]
  internal ICloneChecks<FieldInput> CloneChecks { get; } = new ObjFieldCloneChecks<FieldInput, OutputFieldAst>(
    CreateOutput,
    (original, input) => original with { Name = input.Name });

  internal static OutputFieldAst CreateOutput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);
}

internal sealed class OutputFieldAstChecks()
  : AstObjectFieldChecks<OutputFieldAst>(OutputFieldAstTests.CreateOutput)
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";
}

internal sealed class OutputFieldAstTypeChecks()
  : ObjFieldTypeChecks<FieldInput, OutputFieldAst>(OutputFieldAstTests.CreateOutput)
{
  protected override OutputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override OutputFieldAst WithModifiers(OutputFieldAst objType)
    => objType with { Modifiers = TestMods() };
}
