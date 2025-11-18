using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public partial class InputParamAstTests
{
  [CheckTests(Inherited = true)]
  internal IInputFieldTypeChecks<TypeInput> FieldTypeChecks { get; }
    = new InputParamAstChecks();

  [CheckTests]
  internal IModifiersChecks<TypeInput> ModifiersChecks { get; }
    = new ObjFieldModifiersChecks<TypeInput, InputParamAst>(
      CreateInput,
      ast => ast with { Modifiers = TestMods() });

  [CheckTests]
  internal ICloneChecks<TypeInput> CloneChecks { get; } = new ObjFieldCloneChecks<TypeInput, InputParamAst>(
    CreateInput,
    (original, input) => original with { Type = ObjFieldTypeChecks<TypeInput, InputParamAst>.CreateBase(input) });

  internal static InputParamAst CreateInput(TypeInput input, IGqlpObjBase objBase)
    => new(AstNulls.At, objBase);
}

internal sealed class InputParamAstChecks()
  : InputFieldTypeChecks<TypeInput, InputParamAst>(InputParamAstTests.CreateInput)
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
