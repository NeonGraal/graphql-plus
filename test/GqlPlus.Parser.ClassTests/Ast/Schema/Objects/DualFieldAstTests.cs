using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst> _checks = new(CreateDual, CloneDual);

  private static DualFieldAst CloneDual(DualFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static DualFieldAst CreateDual(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}

public class DualFieldAstTypeTests
    : ObjFieldTypeTests<FieldInput>
{
  private readonly DualFieldAstTypeChecks _checks = new(CreateInput, CloneInput);

  private static DualFieldAst CloneInput(DualFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static DualFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IObjFieldTypeChecks<FieldInput> FieldChecks => _checks;

  protected override string InputString(FieldInput input)
    => $"( !DF {input.Name} : {input.Type} )";
}

internal sealed class DualFieldAstTypeChecks(
  ObjFieldTypeChecks<FieldInput, DualFieldAst>.TypeBy createType,
  BaseAstChecks<DualFieldAst>.CloneBy<FieldInput> cloneInput
) : ObjFieldTypeChecks<FieldInput, DualFieldAst>(createType, cloneInput)
{
  protected override DualFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override DualFieldAst WithModifiers(DualFieldAst objType)
    => objType with { Modifiers = TestMods() };
}
