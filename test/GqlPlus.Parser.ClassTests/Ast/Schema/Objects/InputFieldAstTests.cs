using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputFieldAstTests
  : AstObjFieldBaseTests
{
  internal override IAstObjectFieldChecks FieldChecks { get; }
    = new InputFieldAstChecks();
}

internal sealed class InputFieldAstChecks()
  : AstObjectFieldChecks<InputFieldAst>(InputFieldFactory.Create)
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";
}

public class InputFieldAstTypeTests
    : InputFieldTypeTests<FieldInput>
{
  internal override IInputFieldTypeChecks<FieldInput> InputFieldChecks { get; }
    = new InputFieldAstTypeChecks();

  protected override string InputString(FieldInput input)
    => $"( !IF {input.Name} : {input.Type} )";
}

internal sealed class InputFieldAstTypeChecks()
  : InputFieldTypeChecks<FieldInput, InputFieldAst>(InputFieldFactory.Create)
{
  protected override InputFieldAst CreateEnum(FieldInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override string DefaultString(FieldInput input, string def)
    => $"( !IF {input.Name} : {input.Type} =( !k '{def}' ) )";
  protected override InputFieldAst WithDefault(InputFieldAst objType, string def)
    => objType with { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) };
  protected override InputFieldAst WithModifiers(InputFieldAst objType)
    => objType with { Modifiers = TestMods() };

  protected override string InputString(FieldInput input)
    => $"( !IF {input.Name} : {input.Type} )";
}

internal static class InputFieldFactory
{
  internal static InputFieldAst Clone(InputFieldAst original, FieldInput input)
    => original with { Name = input.Name };
  internal static InputFieldAst Create(FieldInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, input.Name, objBase);
}
