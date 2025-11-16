using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputParamAstTests
  : InputFieldTypeTests<TypeInput>
{
  internal override InputParamAstChecks InputFieldChecks { get; }
    = new(CreateInput);

  private static InputParamAst CloneInput(InputParamAst original, TypeInput input)
    => original with { Type = new ObjBaseAst(AstNulls.At, input.Type, "") };
  private static InputParamAst CreateInput(TypeInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, objBase);
}

internal sealed class InputParamAstChecks(
  ObjFieldTypeChecks<TypeInput, InputParamAst>.TypeBy createType
) : InputFieldTypeChecks<TypeInput, InputParamAst>(createType)
{
  protected override InputParamAst CreateEnum(TypeInput input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) };
  protected override string DefaultString(TypeInput input, string def)
    => $"( !Pa {input.Type} =( !k '{def}' ) )";
  protected override InputParamAst WithDefault(InputParamAst objType, string def)
    => objType with { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) };
  protected override InputParamAst WithModifiers(InputParamAst objType)
    => objType with { Modifiers = TestMods() };
}
