using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputFieldAstTests
  : AstObjFieldBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithParam(FieldInput input, string[] parameters)
      => _checks.HashCode(
        () => new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { Params = parameters.Params() });

  [Theory, RepeatData]
  public void Text_WithParams(FieldInput input, string[] parameters)
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

  private readonly OutputFieldAstChecks _checks = new();

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}

internal sealed class OutputFieldAstChecks()
  : AstObjectFieldChecks<OutputFieldAst>(OutputFieldFactory.Create)
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";
}

public class OutputFieldAstTypeTests
    : ObjFieldTypeBaseTests<FieldInput>
{
  internal override IObjFieldTypeChecks<FieldInput> FieldChecks { get; }
    = new OutputFieldAstTypeChecks();

  protected override string InputString(FieldInput input)
    => $"( !OF {input.Name} : {input.Type} )";
}

internal sealed class OutputFieldAstTypeChecks()
  : ObjFieldTypeChecks<FieldInput, OutputFieldAst>(OutputFieldFactory.Create)
{
  protected override OutputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override OutputFieldAst WithModifiers(OutputFieldAst objType)
    => objType with { Modifiers = TestMods() };
}

internal static class OutputFieldFactory
{
  internal static OutputFieldAst Clone(OutputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  internal static OutputFieldAst Create(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);
}
