using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputFieldAstTests
  : AstObjectFieldTests
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<InputFieldAst> _checks = new(CreateInput, CloneInput);

  private static InputFieldAst CloneInput(InputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static InputFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}

public class InputFieldAstTypeTests
    : InputFieldTypeTests<FieldInput>
{
  private static InputFieldAst CloneInput(InputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  private static InputFieldAst CreateInput(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);

  internal override IInputFieldTypeChecks<FieldInput> InputFieldChecks { get; } = new InputFieldAstTypeChecks(CreateInput, CloneInput);

  protected override string InputString(FieldInput input)
    => $"( !IF {input.Name} : {input.Type} )";
}

internal sealed class InputFieldAstTypeChecks(
  ObjFieldTypeChecks<FieldInput, InputFieldAst>.TypeBy createType,
  BaseAstChecks<InputFieldAst>.CloneBy<FieldInput> cloneInput
) : InputFieldTypeChecks<FieldInput, InputFieldAst>(createType, cloneInput)
{
  protected override InputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override string DefaultString(FieldInput input, string def)
    => $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )";
  protected override InputFieldAst WithDefault(InputFieldAst objType, string def)
    => objType with { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) };
  protected override InputFieldAst WithModifiers(InputFieldAst objType)
    => objType with { Modifiers = TestMods() };
}
